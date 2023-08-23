using Application.Common.Interfaces;
using Infrastucture.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastucture
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Hotel> Hotels { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.HasPostgresExtension("uuid-ossp")
            //    .HasPostgresExtension("postgis")
            //   .HasPostgresExtension("dblink")
            //   .HasAnnotation("Relational:Collation", "C.UTF-8");

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // base.OnModelCreating(builder);
        }
    }



}
