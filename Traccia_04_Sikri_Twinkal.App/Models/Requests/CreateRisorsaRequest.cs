using Traccia_04_Sikri_Twinkal.Models.Entities;

namespace Traccia_04_Sikri_Twinkal.App.Models.Requests
{
    public class CreateRisorsaRequest
    {
        public string Nome { get; set; }
        public int Tipologia { get; set; }

        public Risorsa ToEntity()
        {
            var risorsa = new Risorsa();
            risorsa.Nome = Nome;
            risorsa.TipologiaRisorsaId = Tipologia;
            return risorsa;
        }
    }
}
