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
    public class RecommendationConfiguration : IEntityTypeConfiguration<Recommendation>
    {
        public void Configure(EntityTypeBuilder<Recommendation> builder)
        {
            builder.ToTable("recommendation", "projekat");
            builder.HasKey(t => t.Id)
                 .HasName("recommendation_pkey");

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("uuid")
                .IsRequired();

            builder.Property(e => e.TownId)
                .HasColumnName("townId")
                .IsRequired();

            builder.Property(e => e.Price)
                .HasColumnName("price");

            builder.Property(e => e.Departure)
                .HasColumnName("departure");

            builder.HasOne(d => d.Town)
                .WithMany(p => p.Recommendations)
                .HasForeignKey(d => d.TownId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
