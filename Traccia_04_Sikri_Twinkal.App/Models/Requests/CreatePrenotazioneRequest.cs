using Traccia_04_Sikri_Twinkal.Models.Entities;

namespace Traccia_04_Sikri_Twinkal.App.Models.Requests
{
    public class CreatePrenotazioneRequest
    {
        public int? RisorsaId { get; set; }
        public DateOnly DataInizio { get; set; }
        public DateOnly DataFine { get; set; }

        public Prenotazione ToEntity()
        {
            var prenotazione = new Prenotazione();
            prenotazione.RisorsaId = RisorsaId;
            prenotazione.DataInizio = DataInizio;
            prenotazione.DataFine = DataFine;
            return prenotazione;
        }


    }
}
