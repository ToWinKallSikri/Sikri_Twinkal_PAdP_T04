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

        public void AddPrenotazione(Prenotazione prenotazione)
        {
            _prenotazioneRepository.Aggiungi(prenotazione);
            _prenotazioneRepository.Save();
        }

        public List<Prenotazione> GetPrenotazioni()
        {
            return new List<Prenotazione>();
        }

        public List<Prenotazione> GetPrenotazioni(int from, int num, string? name, out int totalNum)
        {
            return _prenotazioneRepository.GetPrenotazioni(from, num, name, out totalNum);
        }
    }
}
