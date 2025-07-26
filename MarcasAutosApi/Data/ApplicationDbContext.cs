using MarcasAutosApi.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace MarcasAutosApi.Data
{
    [ExcludeFromCodeCoverage]
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<CarBrand> CarBrands => Set<CarBrand>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarBrand>().HasData(
            new CarBrand { Id = 1, Name = "Toyota" },
            new CarBrand { Id = 2, Name = "Kia" },
            new CarBrand { Id = 3, Name = "Suzuki" }
        );
        }
    }
}
