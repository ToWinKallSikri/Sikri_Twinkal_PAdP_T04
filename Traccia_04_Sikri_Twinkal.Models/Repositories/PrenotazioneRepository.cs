using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traccia_04_Sikri_Twinkal.Models.Context;
using Traccia_04_Sikri_Twinkal.Models.Entities;

namespace Traccia_04_Sikri_Twinkal.Models.Repositories
{
    public class PrenotazioneRepository : GenericRepository<Prenotazione>
    {
        public PrenotazioneRepository(ServizioDiPrenotazioneContext ctx) : base(ctx) {}

        public List<Prenotazione> GetPrenotazioni(int from, int num, string? nomeRisorsa, out int totalNum)
        {
            var query = _ctx.Prenotazioni.Include(p => p.Risorsa).AsQueryable();

            if (!string.IsNullOrEmpty(nomeRisorsa))
            {
                query = query.Where(w => w.Risorsa.Nome.ToLower().Contains(nomeRisorsa.ToLower()));
            }

            totalNum = query.Count();

            return query.OrderBy(o => o.PrenotazioneId)
                        .Skip(from)
                        .Take(num)
                        .ToList();
        }
    }
}
