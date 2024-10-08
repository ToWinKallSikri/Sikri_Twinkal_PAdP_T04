﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Traccia_04_Sikri_Twinkal.Models.Context;
using Traccia_04_Sikri_Twinkal.Models.Entities;

namespace Traccia_04_Sikri_Twinkal.Models.Repositories
{
    public class RisorsaRepository : GenericRepository<Risorsa>
    {
        public RisorsaRepository(ServizioDiPrenotazioneContext ctx) : base(ctx) {}

        public override Risorsa? Ottieni(object id)
        {
            return _ctx.Risorse
                .Include(r => r.Prenotazioni)
                .FirstOrDefault(r => r.RisorsaId == (int)id);
        }

        public bool Disponibile(int id, DateOnly inizio, DateOnly fine)
        {
            var risorsa = Ottieni(id);
            if (inizio > fine || risorsa == null) 
                return false;
            return ! risorsa.Prenotazioni.Any(p => p.DataInizio < fine && p.DataFine > inizio);
        }

        public IEnumerable<Risorsa> Cerca(DateOnly inizio, DateOnly fine)
        {
            return _ctx.Risorse.Where(r => Disponibile(r.RisorsaId, inizio, fine));
        }

        public List<Risorsa> GetRisorse(int from, int num, string? name, out int totalNum)
        {
            var query = _ctx.Risorse.AsQueryable();
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(w => w.Nome.ToLower().Contains(name.ToLower()));
            }

            totalNum = query.Count();
            return
                query
                .OrderBy(o => o.Nome)
                .Skip(from)
                .Take(num)
                .ToList();
        }

        public int CreaTipologia(string nomeTipologia)
        {
            if (_ctx.TipologiaRisorsa.Any(x => x.Nome == nomeTipologia))
                return 0;
            var tipologia = new TipologiaRisorsa { Nome = nomeTipologia };
            _ctx.TipologiaRisorsa.Add(tipologia);
            _ctx.SaveChanges();
            return tipologia.TipologiaRisorsaId;
        }
    }
}
