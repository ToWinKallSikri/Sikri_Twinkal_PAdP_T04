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
            _risorsaRepository.Save();

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

            var query = _context.Risorse
                .Include(r => r.Prenotazioni)
                .Where(r => !r.Prenotazioni.Any(p => p.DataInizio < dataFine && p.DataFine > dataInizio));

            if (codiceRisorsa.HasValue)
            {
                query = query.Where(r => r.RisorsaId == codiceRisorsa.Value);
            }

            totalItems = query.Count();
            var risorse = query
                .Skip(from * num)
                .Take(num)
                .OrderBy(r => r.Nome);

            var risorseDto = risorse.Select(r => new RisorsaDto
            {
                Id = r.RisorsaId,
                Nome = r.Nome,
                Tipologia = r.TipologiaRisorsaId

            }).ToList();

            return risorseDto;
        }

        public bool CreaTipologia(string nomeTipologia, out int id)
        {
            id = 0;
            if (string.IsNullOrEmpty(nomeTipologia)) {
                return false;
            }
            id = _risorsaRepository.CreaTipologia(nomeTipologia);
            return id != 0;
        }
    }
}
