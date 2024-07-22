using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Traccia_04_Sikri_Twinkal.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traccia_04_Sikri_Twinkal.Models.Configurations
{
    internal class PrenotazioneConfiguration : IEntityTypeConfiguration<Prenotazione>
    {
        public void Configure(EntityTypeBuilder<Prenotazione> builder)
        {
            builder.ToTable("Prenotazioni");
            builder.HasKey(p => p.PrenotazioneId);
            builder.HasOne(u => u.Utente)
                .WithMany(p => p.Prenotazioni)
                .HasForeignKey(p => p.UtenteId);
            builder.HasOne(r => r.Risorsa)
                .WithMany(p => p.Prenotazioni)
                .HasForeignKey(p => p.RisorsaId);
        }
    }
}
