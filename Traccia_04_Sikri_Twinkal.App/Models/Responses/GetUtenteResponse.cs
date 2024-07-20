using Traccia_04_Sikri_Twinkal.App.Models.Dtos;

namespace Traccia_04_Sikri_Twinkal.App.Models.Responses
{
    public class GetUtenteResponse
    {
        public List<UtenteDto> Utenti { get; set; } = new List<UtenteDto>();
        public int PageNumber { get; set; }

    }
}
