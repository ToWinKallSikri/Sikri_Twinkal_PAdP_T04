using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Traccia_04_Sikri_Twinkal.Models.Context;
using Traccia_04_Sikri_Twinkal.Models.Entities;

namespace Traccia_04_Sikri_Twinkal.Models.Repositories
{
    public class RisorsaRepository : GenericRepository<Risorsa>
    {
        public RisorsaRepository(ServizioDiPrenotazioneContext ctx) : base(ctx) {}

        public override Risorsa? Ottieni(object id)
        {
            return _ctx.Risorse
                .Include(r => r.Prenotazioni)
                .FirstOrDefault(r => r.RisorsaId == (int)id);
        }

        public bool Disponibile(int id, DateOnly inizio, DateOnly fine)
        {
            var risorsa = Ottieni(id);
            if (inizio > fine || risorsa == null) 
                return false;
            return ! risorsa.Prenotazioni.Any(p => p.DataInizio < fine && p.DataFine > inizio);
        }

        public IEnumerable<Risorsa> Cerca(DateOnly inizio, DateOnly fine)
        {
            return _ctx.Risorse.Where(r => Disponibile(r.RisorsaId, inizio, fine));
        }
    }
}
