using Microsoft.EntityFrameworkCore;
using Traccia_04_Sikri_Twinkal.Abstractions;
using Traccia_04_Sikri_Twinkal.Models.Context;
using Traccia_04_Sikri_Twinkal.Models.Entities;

namespace Traccia_04_Sikri_Twinkal.Test.Orm
{
    public class EntityFramework : IExample
    { 
        public async Task RunExampleAsync()
        {

            var ctx = new ServizioDiPrenotazioneContext();

            var utenti = await ctx.Utenti.ToListAsync();
            await DeleteUtenteAsync(ctx);
            await AddRisorsaTipologiaAsync(ctx);
            await AddUtenteAsync(ctx);
            await AddRisorsaAsync(ctx);
            await AddPrenotazioneAsync(ctx);
        }

        public async Task AddPrenotazioneAsync(ServizioDiPrenotazioneContext ctx)
        {
            var prenotazioni = new List<Prenotazione>
    {

            new Prenotazione
            {
                DataInizio = new DateOnly(2024, 10, 1) ,
                DataFine = new DateOnly(2024, 11, 5),
                RisorsaId = 1
            },

            new Prenotazione
            {
                DataInizio = new DateOnly(2024, 12, 4),
                DataFine = new DateOnly(2025, 1, 6),
                RisorsaId = 2
            },

            new Prenotazione
            {
                DataInizio = new DateOnly(2024, 9, 7),
                DataFine = new DateOnly(2024, 10, 8),
                RisorsaId = 3
            },

            new Prenotazione
            {
                DataInizio = new DateOnly(2024, 11, 7),
                DataFine = new DateOnly(2024, 12, 8),
                RisorsaId = 4
            },

    };

            foreach (var prenotazione in prenotazioni)
            {
                var risorsaEsiste = await ctx.Risorse.AnyAsync(r => r.RisorsaId == prenotazione.RisorsaId);
                if (!risorsaEsiste)
                {
                    Console.WriteLine($"La risorsa con ID {prenotazione.RisorsaId} non esiste. Prenotazione non inserita.");
                    continue;
                }

                var prenotazioneConflittuale = await ctx.Prenotazioni.AnyAsync(p =>
                    p.RisorsaId == prenotazione.RisorsaId &&
                    (
                        (prenotazione.DataInizio < p.DataFine && prenotazione.DataFine > p.DataInizio) ||
                        (prenotazione.DataFine > p.DataInizio && prenotazione.DataInizio < p.DataFine)
                    ));

                if (!prenotazioneConflittuale)
                {
                    ctx.Prenotazioni.Add(prenotazione);
                }
                else
                {
                    Console.WriteLine($"Conflitto trovato per la risorsa {prenotazione.RisorsaId} nel periodo {prenotazione.DataInizio} - {prenotazione.DataFine}. Prenotazione non inserita.");
                }
            }

            await ctx.SaveChangesAsync();
        }

        public async Task AddUtenteAsync(ServizioDiPrenotazioneContext ctx)
        {
            var utenti = new List<Utente>
            {

                new Utente
                {
                    Nome = "Mario",
                    Cognome = "Rossi",
                    Email = "prova1@mail.it",
                    Password = "12345",
                },

                new Utente
                {
                    Nome = "Luca",
                    Cognome = "Bianchi",
                    Email = "prova2@mail.it",
                    Password = "123456",
                },

                new Utente
                {
                    Nome = "Paolo",
                    Cognome = "Verdi",
                    Email = "prova2@mail.it",
                    Password = "123466",
                },

                new Utente
                {
                    Nome = "Mauro",
                    Cognome = "Grigi",
                    Email = "prova3@mail.it",
                    Password = "98765",
                },

                new Utente
                {
                    Nome = "Giorgio",
                    Cognome = "Azzurri",
                    Email = "prova5@mail.it",
                    Password = "465465",
                },

                new Utente
                {
                    Nome = "Marco",
                    Cognome = "Verdi",
                    Email = "prova6@mail.it",
                    Password = "23432432",
                },

                new Utente
                {
                    Nome = "Tommaso",
                    Cognome = "Rossi",
                    Email = "prova7@mail.it",
                    Password = "53453",
                },

                new Utente
                {
                    Nome = "Roberto",
                    Cognome = "Rossi",
                    Email = "prova8@mail.it",
                    Password = "53453",
                },

                new Utente
                {
                    Nome = "Riccardo",
                    Cognome = "Rossi",
                    Email = "prova10@mail.it",
                    Password = "564564646",
                },

                new Utente
                {
                    Nome = "Luigi",
                    Cognome = "Neri",
                    Email = "prova19@mail.it",
                    Password = "45645645645",
                }
            };

            foreach (var nuovoUtente in utenti)
            {
                var esisteUtente = ctx.Utenti
                    .Any(u => u.Email == nuovoUtente.Email);

                if (!esisteUtente)
                {
                    ctx.Utenti.Add(nuovoUtente);
                }
            }

            await ctx.SaveChangesAsync();
        }

        public async Task DeleteUtenteAsync(ServizioDiPrenotazioneContext ctx)
        {

            var utentiDaCancellare = ctx.Utenti
                .Where(u => u.UtenteId >= 34 && u.UtenteId <= 35)
                .ToList();

            foreach (var utente in utentiDaCancellare)
            {
                ctx.Utenti.Remove(utente);
            }

            await ctx.SaveChangesAsync();
        }

        public async Task AddRisorsaTipologiaAsync(ServizioDiPrenotazioneContext ctx)
        {
            var risorseTipologia = new List<TipologiaRisorsa>
            {

                new TipologiaRisorsa
                {
                    TipologiaRisorsaId = 1,
                    Nome = "Ristoranti",
                },
                
                new TipologiaRisorsa
                {
                    TipologiaRisorsaId = 2,
                    Nome = "Sala Riunioni",
                },

                new TipologiaRisorsa
                {
                    TipologiaRisorsaId = 3,
                    Nome = "Hotel",
                },

                new TipologiaRisorsa
                {
                    TipologiaRisorsaId = 4,
                    Nome = "Auto",
                },

                new TipologiaRisorsa
                {
                    TipologiaRisorsaId = 5,
                    Nome = "Pub",
                }

            };

            foreach (var tipologia in risorseTipologia)
            {
                var esistente = ctx.TipologiaRisorsa
                    .AsNoTracking()
                    .FirstOrDefault(rt => rt.TipologiaRisorsaId == tipologia.TipologiaRisorsaId);

                if (esistente == null)
                {
                    ctx.TipologiaRisorsa.Add(tipologia);
                }
            }


            await ctx.SaveChangesAsync();
        }
        public async Task AddRisorsaAsync(ServizioDiPrenotazioneContext ctx)
        {
            var risorse = new List<Risorsa>
            {
                new Risorsa
                {
                    RisorsaId = 1,
                    Nome = "AUDI A1",
                    TipologiaRisorsaId = 4,
                },

                new Risorsa
                {
                    RisorsaId = 3,
                    Nome = "FIAT 500",
                    TipologiaRisorsaId = 4,
                },

                new Risorsa
                {
                    RisorsaId = 10,
                    Nome = "PANDA",
                    TipologiaRisorsaId = 4,
                },

                new Risorsa
                {
                    RisorsaId = 2,
                    Nome = "PUNTO",
                    TipologiaRisorsaId = 4,
                },

                new Risorsa
                {
                    RisorsaId = 40,
                    Nome = "POLO",
                    TipologiaRisorsaId = 4,
                },

                new Risorsa
                {
                    RisorsaId = 4,
                    Nome = "Gigilio",
                    TipologiaRisorsaId = 2,
                },

                new Risorsa
                {
                    RisorsaId = 5,
                    Nome = "Rovere",
                    TipologiaRisorsaId = 2,
                },

                new Risorsa
                {
                    RisorsaId = 6,
                    Nome = "Aula Magna",
                    TipologiaRisorsaId = 2,
                },

                new Risorsa
                {
                    RisorsaId = 7,
                    Nome = "Bella Napoli",
                    TipologiaRisorsaId = 1,
                },

                new Risorsa
                {
                    RisorsaId = 8,
                    Nome = "Lo Scalino",
                    TipologiaRisorsaId = 1,
                },

                new Risorsa
                {
                    RisorsaId = 20,
                    Nome = "Sora Lella",
                    TipologiaRisorsaId = 1,
                },

                new Risorsa
                {
                    RisorsaId = 30,
                    Nome = "I TRE ARCHI",
                    TipologiaRisorsaId = 1,
                },
            };

            foreach (var nuovaRisorsa in risorse)
            {
                var esisteRisorsa = ctx.Risorse
                    .Any(r => r.RisorsaId == nuovaRisorsa.RisorsaId);

                if (!esisteRisorsa)
                {
                    ctx.Risorse.Add(nuovaRisorsa);
                }
            }

            await ctx.SaveChangesAsync();
        }


    }
}
