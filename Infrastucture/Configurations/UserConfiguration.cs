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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user", "projekat");
            builder.HasKey(t => t.Id)
                   .HasName("user_pkey");

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("uuid")
                .IsRequired();

            builder.Property(e => e.Name)
                .HasColumnName("name");

            builder.Property(e => e.Lastname)
                .HasColumnName("lastname");

            builder.Property(e => e.Email)
                .HasColumnName("email");

            builder.Property(e => e.Username)
                .HasColumnName("username");
        }
    }
}
