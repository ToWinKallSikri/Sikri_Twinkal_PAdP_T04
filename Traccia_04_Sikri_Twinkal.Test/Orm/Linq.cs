using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traccia_04_Sikri_Twinkal.Abstractions;
using Traccia_04_Sikri_Twinkal.Models.Context;

namespace Traccia_04_Sikri_Twinkal.Test.Orm
{
    public class Linq : IExample
    {
        public async Task RunExampleAsync()
        {
            var ctx = new ServizioDiPrenotazioneContext();

            var risorse = await ctx.Risorse.ToListAsync();
            var queryResult = risorse.GroupBy(g => g.TipologiaRisorsaId);

            foreach (var item in queryResult)
            {
                Console.WriteLine($"Tipologia di Risorsa con codice {item.Key}:");
                foreach (var risorsa in item)
                {
                    Console.WriteLine($"{risorsa.Nome} {risorsa.RisorsaId}\n");
                }
            }
        }
    }
}
