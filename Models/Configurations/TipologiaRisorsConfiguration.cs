using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traccia_04_Sikri_Twinkal.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Traccia_04_Sikri_Twinkal.Models.Configurations
{
    public class TipologiaRisorsConfiguration : IEntityTypeConfiguration<TipologiaRisorsa>
    {
        public void Configure(EntityTypeBuilder<TipologiaRisorsa> builder)
        {
            builder.ToTable("TipologieRisorse");
            builder.HasKey(t => t.TipologiaRisorsaId);
        }
    }

   
}
