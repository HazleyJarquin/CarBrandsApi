using MarcasAutosApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace MarcasAutosApi.Data
{
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
