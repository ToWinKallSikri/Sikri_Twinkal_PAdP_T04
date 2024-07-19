using Traccia_04_Sikri_Twinkal.Models.Entities;

namespace Traccia_04_Sikri_Twinkal.App.Abstractions.Services
{
    public interface IUtenteService
    {
        List<Utente> GetUtenti();
        Utente GetUtenteById(int id);
        void AddUtente(Utente utente);

    }
}
