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
    internal class RisorsaConfiguration : IEntityTypeConfiguration<Risorsa>
    {
        public void Configure(EntityTypeBuilder<Risorsa> builder)
        {
            builder.ToTable("Risorse");
            builder.HasKey(r => r.RisorsaId);
        }
    }
}
