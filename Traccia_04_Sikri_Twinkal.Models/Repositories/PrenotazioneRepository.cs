using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traccia_04_Sikri_Twinkal.Models.Context;
using Traccia_04_Sikri_Twinkal.Models.Entities;

namespace Traccia_04_Sikri_Twinkal.Models.Repositories
{
    public class PrenotazioneRepository : GenericRepository<Prenotazione>
    {
        public PrenotazioneRepository(ServizioDiPrenotazioneContext ctx) : base(ctx) {}

        public IEnumerable<Prenotazione> GetPrenotazioni(DateOnly inizio, DateOnly fine, int RisorsaId)
        {
            if (inizio < DateOnly.FromDateTime(DateTime.Now))
            {
                throw new ArgumentException("La data di inizio deve essere maggiore o uguale alla data odierna");
            }
            if (inizio > fine)
            {
                throw new ArgumentException("La data di inizio deve essere minore della data di fine");
            }
            
            return _ctx.Prenotazioni
                .Where(p => p.DataInizio < fine && p.DataFine > inizio && p.RisorsaId == RisorsaId);
        }
    }
}
