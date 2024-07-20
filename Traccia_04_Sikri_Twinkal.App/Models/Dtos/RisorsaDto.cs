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
            Tipologia = risorsa.Tipologia;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Tipologia { get; set; }
    }
}
