using Traccia_04_Sikri_Twinkal.App.Models.Dtos;

namespace Traccia_04_Sikri_Twinkal.App.Models.Responses
{
    public class GetRisorsaResponse
    {
        public List<RisorsaDto> Risorse { get; set; } = new List<RisorsaDto>();
        public int PageNumber { get; set; }
    }
}
