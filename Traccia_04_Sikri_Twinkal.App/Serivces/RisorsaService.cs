using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Traccia_04_Sikri_Twinkal.App.Abstractions.Services;
using Traccia_04_Sikri_Twinkal.Models.Repositories;
using Traccia_04_Sikri_Twinkal.Models.Entities;
using Traccia_04_Sikri_Twinkal.Models.Context;

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
        public void addRisorsa(Risorsa ris)
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
    }
}
