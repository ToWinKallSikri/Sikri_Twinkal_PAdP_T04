using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traccia_04_Sikri_Twinkal.Models.Entities
{
    public class TipologiaRisorsa
    {
        public int TipologiaRisorsaId { get; set; }
        public string Nome { get; set; } = string.Empty;
        public virtual IEnumerable<Risorsa> Risorse { get; set; } = null!;
    }
}
