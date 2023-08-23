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
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.ToTable("hotel", "projekat");
            builder.HasKey(t => t.Id)
                 .HasName("hotel_pkey");


            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("uuid")
                .IsRequired();

            builder.Property(e => e.Name)
                .HasColumnName("name")
                .IsRequired();

            builder.Property(e => e.NumberStar)
                .HasColumnName("numberStar");

            builder.Property(e => e.RoomNumber)
                .HasColumnName("roomNumber");

            builder.Property(e => e.TownId)
                .HasColumnName("townId")
                .IsRequired();

            builder.HasOne(d => d.Town)
                .WithMany(p => p.Hotels)
                .HasForeignKey(d => d.TownId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
