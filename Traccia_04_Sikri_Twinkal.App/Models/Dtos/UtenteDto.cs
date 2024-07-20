using Traccia_04_Sikri_Twinkal.Models.Entities;

namespace Traccia_04_Sikri_Twinkal.App.Models.Dtos
{
    public class UtenteDto
    {
        public UtenteDto() { }

        public UtenteDto(Utente utente) 
        { 
            UtenteId = utente.UtenteId;
            Nome = utente.Nome;
            Cognome = utente.Cognome;
            Email = utente.Email;
            Password = utente.Password;
               
        }
        public int UtenteId { get; set; }
        public string Nome { get; set; } 
        public string Cognome { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
