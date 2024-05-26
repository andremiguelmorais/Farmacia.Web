using Farmacia.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Medicamentos> Medicamentos { get; set; }
        public DbSet<Fabricas> Fabricas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Medicamentos>().HasData(
                new Medicamentos
                {
                    Id = 1,
                    Name = "Benuron",
                    Description = "txt",
                    Price = 28,
                    Amount = 20,
                    ImageUrl = "https://placehold.co/600x400",
                },
                new Medicamentos
                {
                    Id = 2,
                    Name = "Paracetamol",
                    Description = "Analgésico e antipirético",
                    Price = 15,
                    Amount = 30,
                    ImageUrl = "https://placehold.co/600x400",
                },
                new Medicamentos
                {
                    Id = 3,
                    Name = "Amoxicilina",
                    Description = "Antibiótico de amplo espectro",
                    Price = 10,
                    Amount = 25,
                    ImageUrl = "https://placehold.co/600x400",
                },
                 new Medicamentos
                 {
                     Id = 4,
                     Name = "Ibuprofeno",
                     Description = "Anti-inflamatório não esteroide",
                     Price = 20,
                     Amount = 40,
                     ImageUrl = "https://placehold.co/600x400"
                 }


                ); ;
            modelBuilder.Entity<Fabricas>().HasData(
              new Fabricas
              {
                  Id = 1,
                  Name = "AbbVie Portugal",
                  Medicamentos_Id = 1,
                  Local = "Estrada Alfragide 67 Alfrapark, Edifício D, 2610-008 Amadora, Portugal"
              },
              new Fabricas
                {
                    Id = 2,
                    Name = "Pfizer Portugal",
                    Medicamentos_Id = 2,
                    Local = "Lagoas Park, Edifício 10, Piso 0, 2740-244 Porto Salvo, Portugal"
                },
              new Fabricas
                {
                    Id = 3,
                    Name = "Bayer Portugal",
                    Medicamentos_Id = 3,
                    Local = "Rua da Quinta do Pinheiro, 5, 2790-143 Carnaxide, Portugal"
                },
    new Fabricas
    {
        Id = 4,
        Name = "Novartis Portugal",
        Medicamentos_Id = 4,
        Local = "Quinta da Fonte, Edifício D. Amélia, 2770-192 Paço de Arcos, Portugal"
    },
    new Fabricas
    {
        Id = 5,
        Name = "Merck Sharp & Dohme Portugal",
        Medicamentos_Id = 1,
        Local = "Lagoas Park, Edifício 14, Piso 0, 2740-262 Porto Salvo, Portugal"
    },
    new Fabricas
    {
        Id = 6,
        Name = "Johnson & Johnson Portugal",
        Medicamentos_Id = 2,
        Local = "Rua 25 de Abril 25, 2740-262 Porto Salvo, Portugal"
    },
     new Fabricas
     {
         Id = 7,
         Name = "Johnson & Johnson Portugal",
         Medicamentos_Id = 2,
         Local = "Rua 25 de Abril 25, 2740-262 Porto Salvo, Portugal"
     }


                );
        }
    }

}
