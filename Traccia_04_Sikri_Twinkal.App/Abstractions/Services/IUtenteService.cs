using Traccia_04_Sikri_Twinkal.App.Models.Requests;
using Traccia_04_Sikri_Twinkal.Models.Entities;

namespace Traccia_04_Sikri_Twinkal.App.Abstractions.Services
{
    public interface IUtenteService
    {
        bool CreateToken(CreateTokenRequest tokenRequest, out string token);
        List<Utente> GetUtenti();
        List<Utente> GetUtenti(int from, int num, string? name, out int totalNum);
        Utente? GetUtenteById(int id);
        void AddUtente(Utente utente);

    }
}
