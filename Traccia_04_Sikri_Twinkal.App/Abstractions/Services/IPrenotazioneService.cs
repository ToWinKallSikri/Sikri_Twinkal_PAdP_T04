using Traccia_04_Sikri_Twinkal.Models.Entities;

namespace Traccia_04_Sikri_Twinkal.App.Abstractions.Services
{
    public interface IPrenotazioneService
    {
        List<Prenotazione> GetPrenotazioni();

        List<Prenotazione> GetPrenotazioni(int from, int num, string? name, out int totalNum);

        void AddPrenotazione(Prenotazione prenotazione);
        
    }
}
