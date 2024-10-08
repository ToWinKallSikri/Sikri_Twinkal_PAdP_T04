﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traccia_04_Sikri_Twinkal.Models.Entities
{
    public class Risorsa
    {
        public int RisorsaId { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int TipologiaRisorsaId { get; set; }
        public virtual TipologiaRisorsa TipologiaRisorsa { get; set; }
        public virtual IEnumerable<Prenotazione> Prenotazioni { get; set; } = [];
    }
}
