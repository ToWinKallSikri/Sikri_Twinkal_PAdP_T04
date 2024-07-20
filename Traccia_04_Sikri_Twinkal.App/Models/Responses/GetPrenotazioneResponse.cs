using Traccia_04_Sikri_Twinkal.App.Models.Dtos;

namespace Traccia_04_Sikri_Twinkal.App.Models.Responses
{
    public class GetPrenotazioneResponse
    {
        public List<PrenotazioneDto> Prenotazioni { get; set; } = new List<PrenotazioneDto>();
        public int PageNumber { get; set; }
    }
}
