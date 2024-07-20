using Traccia_04_Sikri_Twinkal.Models.Entities;

namespace Traccia_04_Sikri_Twinkal.App.Models.Requests
{
    public class CreateUtenteRequest
    {
        public int UtenteId { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Utente ToEntity()
        {
            var utente = new Utente();
            utente.UtenteId = UtenteId;
            utente.Nome = Nome;
            utente.Cognome = Cognome;
            utente.Email = Email;
            utente.Password = Password;
            return utente;
        }
    }
}
