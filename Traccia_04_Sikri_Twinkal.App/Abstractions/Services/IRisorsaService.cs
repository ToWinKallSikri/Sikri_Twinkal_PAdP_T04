using Traccia_04_Sikri_Twinkal.Models.Entities;

namespace Traccia_04_Sikri_Twinkal.App.Abstractions.Services
{
    public interface IRisorsaService
    {
        List<Risorsa> GetRisorse();

        List<Risorsa> GetRisorsa(int RisorsaId, string Tipologia);

        void addRisorsa(Risorsa ris);

        void getRisorsa(int RisorsaId);

        bool risorsaExists(int RisorsaId);



    }
}
