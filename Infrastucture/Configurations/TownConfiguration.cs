using Infrastucture.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastucture.Configurations
{
    public class TownConfiguration : IEntityTypeConfiguration<Town>
    {
        public void Configure(EntityTypeBuilder<Town> builder)
        {
            builder.ToTable("town", "projekat");
            builder.HasKey(t => t.Id)
                 .HasName("town_pkey");


            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("uuid")
                .IsRequired();

            builder.Property(e => e.Name)
                .HasColumnName("name")
                .IsRequired();

            builder.Property(e => e.CountryId)
                .HasColumnName("countryId")
                .IsRequired();

            builder.Property(e => e.Description)
                .HasColumnName("description");


            builder.HasOne(d => d.Country)
                    .WithMany(p => p.Towns)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
