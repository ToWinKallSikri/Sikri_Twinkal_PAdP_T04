using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Traccia_04_Sikri_Twinkal.App.Abstractions.Services;
using Traccia_04_Sikri_Twinkal.Models.Repositories;
using Traccia_04_Sikri_Twinkal.Models.Entities;
using Traccia_04_Sikri_Twinkal.Models.Context;
using Traccia_04_Sikri_Twinkal.App.Models.Dtos;

namespace Traccia_04_Sikri_Twinkal.App.Serivces
{
    public class RisorsaService : IRisorsaService
    {

        private readonly RisorsaRepository _risorsaRepository;
        private readonly ServizioDiPrenotazioneContext _context;

        public RisorsaService(ServizioDiPrenotazioneContext context, RisorsaRepository risorsaRepository)
        {
            _context = context;
            _risorsaRepository = risorsaRepository;
        }
        public void AddRisorsa(Risorsa ris)
        {
            _risorsaRepository.Aggiungi(ris);

        }

        public Risorsa? GetRisorsa(object RisorsaId)
        {
            return _risorsaRepository.Ottieni(RisorsaId);
        }

        public List<Risorsa> GetRisorse()
        {
            return _context.Risorse.ToList();
            
        }

        public bool risorsaExists(int RisorsaId)
        {
            return _risorsaRepository.Ottieni(RisorsaId) != null;
        }

        public List<Risorsa> GetRisorse(int from, int num, string? name, out int totalNum)
        {
            return _risorsaRepository.GetRisorse(from, num, name, out totalNum);
        }

        public List<RisorsaDto> GetDisponibilita(int from, int num, DateOnly dataInizio, DateOnly dataFine, int? codiceRisorsa, out int totalItems)
        {
            from = Math.Max(from, 0);

            codiceRisorsa = codiceRisorsa == 0 ? null : codiceRisorsa;

            var query = _context.Risorse
                .Include(r => r.Prenotazioni)
                .Where(r => !r.Prenotazioni.Any(p => (p.DataInizio < dataFine && p.DataFine > dataInizio)));

            if (codiceRisorsa.HasValue)
            {
                query = query.Where(r => r.RisorsaId == codiceRisorsa.Value);
            }

            totalItems = query.Count();

            var risorse = query
                .OrderBy(r => r.Nome)
                .Skip(from * num)
                .Take(num)
                .ToList();

            var risorseDto = risorse.Select(r => new RisorsaDto
            {
                Id = r.RisorsaId,
                Nome = r.Nome,
                Tipologia = r.TipologiaRisorsaId

            }).ToList();

            return risorseDto;
        }
    }
}
