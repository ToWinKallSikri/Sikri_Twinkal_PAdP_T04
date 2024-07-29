using Traccia_04_Sikri_Twinkal.App.Abstractions.Services;
using Traccia_04_Sikri_Twinkal.Models.Entities;
using Traccia_04_Sikri_Twinkal.Models.Repositories;

namespace Traccia_04_Sikri_Twinkal.App.Serivces
{
    public class UtenteService : IUtenteService
    {
        private readonly UtenteRepository _utenteRepository;

        public UtenteService(UtenteRepository utenteRepository)
        {
            _utenteRepository = utenteRepository;
        }

        public List<Utente> GetUtenti()
        {
            return new List<Utente>();
            
        }

        public Utente? GetUtenteById(int id)
        {
            return _utenteRepository.Ottieni(id);
        }

        public void AddUtente(Utente utente)
        {
            _utenteRepository.Aggiungi(utente);
        }

        public List<Utente> GetUtenti(int from, int num, string? name, out int totalNum)
        {
            return _utenteRepository.GetUtenti(from, num, name, out totalNum);
        }
    }
}
