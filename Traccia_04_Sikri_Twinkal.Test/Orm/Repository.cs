using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traccia_04_Sikri_Twinkal.Abstractions;
using Traccia_04_Sikri_Twinkal.Models.Context;
using Traccia_04_Sikri_Twinkal.Models.Entities;
using Traccia_04_Sikri_Twinkal.Models.Repositories;

namespace Traccia_04_Sikri_Twinkal.Test.Orm
{
    public class Repository : IExample
    {

        public async Task RunExampleAsync()
        {
            var ctx = new ServizioDiPrenotazioneContext();
            var utenteRepo = new UtenteRepository(ctx);
            var risorsaRepo = new RisorsaRepository(ctx);

            var utente = utenteRepo.Ottieni(1);

            var risorsa = risorsaRepo.Ottieni(2);
            risorsa.Nome = "CLIO - MODIFICA";
            risorsaRepo.Modifica(risorsa);
            risorsaRepo.Save();

            var nuovaRisorsa = new Risorsa
            {
                Nome = "MASERATI",
                RisorsaId = 50,
                TipologiaRisorsaId = 4,
            };
            risorsaRepo.Aggiungi(nuovaRisorsa);
            risorsaRepo.Save();

        }

    }
}
