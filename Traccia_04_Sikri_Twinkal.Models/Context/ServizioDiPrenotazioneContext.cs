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
        public DbSet<TipologiaRisorsa> TipologiaRisorsa { get; set; }
        public ServizioDiPrenotazioneContext() : base() { }
        public ServizioDiPrenotazioneContext(DbContextOptions<ServizioDiPrenotazioneContext> config) : base(config) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            optionsBuilder.UseSqlServer(@"data source=TWINFOREX; Initial Catalog=BookingContext;Integrated Security=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }


    }
}
