using Microsoft.EntityFrameworkCore;
using Traccia_04_Sikri_Twinkal.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traccia_04_Sikri_Twinkal.Models.Context
{
    public class ServizioDiPrenotazioneContext : DbContext
    {
        public DbSet<Prenotazione> Prenotazioni { get; set; }
        public DbSet<Utente> Utenti { get; set; }
        public DbSet<Risorsa> Risorse { get; set; }
        public ServizioDiPrenotazioneContext() : base() { }
        public ServizioDiPrenotazioneContext(DbContextOptions<ServizioDiPrenotazioneContext> config) : base(config) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Da sostituire con la connessione al db sql
            optionsBuilder.UseInMemoryDatabase("MY_DB");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }







    }
}
