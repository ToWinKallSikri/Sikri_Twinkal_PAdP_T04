using Traccia_04_Sikri_Twinkal.App.Models.Dtos;
using Traccia_04_Sikri_Twinkal.Models.Entities;

namespace Traccia_04_Sikri_Twinkal.App.Abstractions.Services
{
    public interface IRisorsaService
    {
        List<Risorsa> GetRisorse();

        Risorsa? GetRisorsa(object RisorsaId);

        List<Risorsa> GetRisorse(int from, int num, string? name, out int totalNum);

        void AddRisorsa(Risorsa ris);
        List<RisorsaDto> GetDisponibilita(int from, int num, DateOnly dataInizio, DateOnly dataFine, int? codiceRisorsa, out int totalItems);

        bool risorsaExists(int RisorsaId);
        public bool CreaTipologia(string nomeTipologia, out int id);
    }
}
