namespace Traccia_04_Sikri_Twinkal.App.Models.Requests
{
    public class GetPrenotazioneRequest
    {
        public int PageSize { get; set; } 
        public int PageNumber { get; set; }
        public int PrenotazioneId { get; set; }
    }
}
