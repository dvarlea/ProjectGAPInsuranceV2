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
                    Username = "GAPClient",
                    Name = "GAP",
                    LastName = "GAP",
                    Role = Roles.Client
                },
                new User
                {
                    Id = 123456788,
                    Username = "GAPAdmin",
                    Name = "GAPAdmin",
                    LastName = "GAPAdmin",
                    Role = Roles.Admin
                },
                new User
                {
                    Id = 123456787,
                    Username = "GAPClient2",
                    Name = "GAPClient2",
                    LastName = "GAPClient2",
                    Role = Roles.Client
                });

            builder.Entity<Insurance>()
               .HasData(new Insurance
               {
                   Id = 1,
                   Name = "Seguro de Auto",
                   Price = 3000,
                   TimePeriod = 6,
                   Begining = DateTime.Now,
                   ClientId = 123456789,
                   CoverageAmt = 0.6,
                   Coverages = "Accidente, Vandalismo",
                   Description = "Seguro de Auto de GAPClient",
                   Risk = Risks.Medio
               },
               new Insurance
               {
                   Id = 2,
                   Name = "Seguro de Vivienda",
                   Price = 7000,
                   TimePeriod = 12,
                   Begining = DateTime.Now,
                   ClientId = 123456789,
                   CoverageAmt = 0.5,
                   Coverages = "Incendio, Robo",
                   Description = "Seguro de Vivienda de GAPClient",
                   Risk = Risks.Alto
               },
               new Insurance
               {
                   Id = 3,
                   Name = "Seguro de Vida",
                   Price = 2000,
                   TimePeriod = 24,
                   Begining = DateTime.Now,
                   ClientId = 123456789,
                   CoverageAmt = 0.8,
                   Coverages = "Muerte, accidentes",
                   Description = "Seguro de vida de GAPClient",
                   Risk = Risks.Bajo
               },
               new Insurance
               {
                   Id = 4,
                   Name = "Seguro de Desempleo",
                   Price = 50,
                   TimePeriod = 3,
                   Begining = DateTime.Now,
                   ClientId = 123456789,
                   CoverageAmt = 0.4,
                   Coverages = "Desempleo",
                   Description = "Seguro de Desempleo de GAPClient",
                   Risk = Risks.MedioAlto
               },
               new Insurance
               {
                   Id = 5,
                   Name = "Seguro de Vivienda",
                   Price = 200,
                   TimePeriod = 2,
                   Begining = DateTime.Now,
                   ClientId = 123456787,
                   CoverageAmt = 0.9,
                   Coverages = "Incendio, Danos",
                   Description = "Seguro de Vivienda de GAPClient2",
                   Risk = Risks.Bajo
               },
               new Insurance
               {
                   Id = 6,
                   Name = "Seguro de Viaje",
                   Price = 40,
                   TimePeriod = 1,
                   Begining = DateTime.Now,
                   ClientId = 123456787,
                   CoverageAmt = 0.7,
                   Coverages = "Accidente",
                   Description = "Seguro de Viaje de GAPClient2",
                   Risk = Risks.Medio
               }
               );
        }
    }
}
