using Traccia_04_Sikri_Twinkal.App.Abstractions.Services;
using Traccia_04_Sikri_Twinkal.Models.Entities;
using Traccia_04_Sikri_Twinkal.Models.Repositories;

namespace Traccia_04_Sikri_Twinkal.App.Serivces
{
    public class PrenotazioneService : IPrenotazioneService
    {   
        private readonly PrenotazioneRepository _prenotazioneRepository;
        
        public PrenotazioneService(PrenotazioneRepository prenotazioneRepository)
        {
            _prenotazioneRepository = prenotazioneRepository;
        }

        public void addPrenotazione(Prenotazione prenotazione)
        {
            _prenotazioneRepository.Aggiungi(prenotazione).Wait();
            _prenotazioneRepository.Save().Wait();
        }

        public List<Prenotazione> GetPrenotazioni(DateOnly DataInizio, DateOnly DataFine, int RisorsaId)
        {
            return _prenotazioneRepository.GetPrenotazioni(DataInizio, DataFine, RisorsaId).ToList();
        }

        public List<Prenotazione> GetPrenotazioni()
        {
            return new List<Prenotazione>();
        }
    }
}
