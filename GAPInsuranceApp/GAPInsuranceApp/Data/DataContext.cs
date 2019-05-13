using GAPInsuranceApp.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace GAPInsuranceApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Insurance> Insurances { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasData(new User
                {
                    Id = 123456789,
                    Username = "GAPTest",
                    Name = "Juan",
                    LastName = "Rodrigues",
                    Role = Roles.Client
                });

            builder.Entity<Insurance>()
               .HasData(new Insurance
               {
                   Id = 999999,
                   Name = "Seguro de Auto",
                   Price = 230000,
                   TimePeriod = 6,
                   Begining = DateTime.Now,
                   ClientId = 123456789,
                   CoverageAmt = 0.6,
                   Coverages = "Accidente, Robo",
                   Description = "Seguro de Auto de Juan Rodriguez",
                   Risk = Risks.Medio
               },
               new Insurance
               {
                   Id = 999998,
                   Name = "Seguro de Vivienda",
                   Price = 500000,
                   TimePeriod = 12,
                   Begining = DateTime.Now,
                   ClientId = 123456789,
                   CoverageAmt = 0.5,
                   Coverages = "Incendio, Robo",
                   Description = "Seguro de Vivienda de Juan Rodriguez",
                   Risk = Risks.Alto
               }
               );
        }
    }
}
