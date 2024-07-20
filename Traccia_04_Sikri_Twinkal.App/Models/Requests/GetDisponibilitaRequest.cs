namespace Traccia_04_Sikri_Twinkal.App.Models.Requests
{
    public class GetDisponibilitaRequest
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public DateOnly DataInizio { get; set; }
        public DateOnly DataFine { get; set; }
        public int? RisorsaId { get; set; }

    }
}
