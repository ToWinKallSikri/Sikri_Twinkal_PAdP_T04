namespace Traccia_04_Sikri_Twinkal.App.Models.Requests
{
    public class GetUtenteRequest
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int? UtenteId { get; set; }
    }
}
