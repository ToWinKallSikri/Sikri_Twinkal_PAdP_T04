using Traccia_04_Sikri_Twinkal.Models.Entities;

namespace Traccia_04_Sikri_Twinkal.App.Abstractions.Services
{
    public interface IRisorsaService
    {
        List<Risorsa> GetRisorse();

        Risorsa? GetRisorsa(object RisorsaId);

        void addRisorsa(Risorsa ris);

        bool risorsaExists(int RisorsaId);
    }
}
