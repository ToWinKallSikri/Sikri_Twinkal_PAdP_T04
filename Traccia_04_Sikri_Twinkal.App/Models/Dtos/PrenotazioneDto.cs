using Traccia_04_Sikri_Twinkal.Models.Entities;

namespace Traccia_04_Sikri_Twinkal.App.Models.Dtos
{
    public class PrenotazioneDto
    {
        public PrenotazioneDto() {}

        public PrenotazioneDto(Prenotazione prenotazione)
        {
            Id = prenotazione.PrenotazioneId;
            Risorsa = prenotazione.RisorsaId;
            DataInizio = prenotazione.DataInizio;
            DataFine = prenotazione.DataFine;
        }

        public int Id { get; set; }
        public DateOnly DataInizio { get; set; }
        public DateOnly DataFine { get; set; }
        public int Risorsa { get; set; }
    }
}
