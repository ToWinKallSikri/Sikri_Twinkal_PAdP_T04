using Traccia_04_Sikri_Twinkal.Models.Entities;

namespace Traccia_04_Sikri_Twinkal.App.Abstractions.Services
{
    public interface IPrenotazioneService
    {
        List<Prenotazione> GetPrenotazioni();

        List<Prenotazione> GetPrenotazioni(DateOnly DataInizio, DateOnly DataFine, int RisorsaId);
        void addPrenotazione(Prenotazione prenotazione);
        
    }
}
