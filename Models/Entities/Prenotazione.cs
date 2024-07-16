using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traccia_04_Sikri_Twinkal.Models.Entities
{
    public class Prenotazione
    {
        public DateOnly DataInizio { get; set; }
        public DateOnly DataFine { get; set; }
        public virtual Utente Utente { get; set; } = null!;
        public virtual Risorsa Risorsa { get; set; } = null!;
        public int PrenotazioneId { get; set; }
        public int UtenteId { get; set; }
        public int RisorsaId { get; set; }
    }
}
