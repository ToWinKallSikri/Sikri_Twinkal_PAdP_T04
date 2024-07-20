namespace Traccia_04_Sikri_Twinkal.App.Models.Requests
{
    public class GetRisorsaRequest
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int? RisorsaId { get; set; }
    }
}
