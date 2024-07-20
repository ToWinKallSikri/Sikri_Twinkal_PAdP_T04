using Traccia_04_Sikri_Twinkal.Models.Entities;

namespace Traccia_04_Sikri_Twinkal.App.Models.Requests
{
    public class CreateRisorsaRequest
    {
        public int IdRisorsa { get; set; }
        public string Nome { get; set; }
        public string Tipologia { get; set; }

        public Risorsa ToEntity()
        {
            var risorsa = new Risorsa();
            risorsa.RisorsaId = IdRisorsa;
            risorsa.Nome = Nome;
            risorsa.Tipologia = Tipologia;
            return risorsa;
        }
    }
}
