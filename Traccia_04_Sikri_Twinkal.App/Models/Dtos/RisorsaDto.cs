using Traccia_04_Sikri_Twinkal.Models.Entities;

namespace Traccia_04_Sikri_Twinkal.App.Models.Dtos
{
    public class RisorsaDto
    {
        public RisorsaDto() { }

        public RisorsaDto(Risorsa risorsa)
        {
            Id = risorsa.RisorsaId;
            Nome = risorsa.Nome;
            Tipologia = risorsa.TipologiaRisorsaId;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int Tipologia { get; set; }
    }
}
