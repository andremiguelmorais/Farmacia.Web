using Farmacia.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Infrastructure.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { } 
        public DbSet<Medicamentos> Medicamentos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Medicamentos>().HasData(
                new Medicamentos
                {
                    Id = 1,
                    Name = "Benuron",
                    Description="txt",
                    Price=28,
                    Amount=20,
                    ImageUrl= "https://placehold.co/600x400",
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


                );;
        }
    }
}
