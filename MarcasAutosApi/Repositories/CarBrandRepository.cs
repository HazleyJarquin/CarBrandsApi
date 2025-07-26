using MarcasAutosApi.Data;
using MarcasAutosApi.Entities;
using MarcasAutosApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
namespace MarcasAutosApi.Repositories
{

    public class CarBrandRepository : ICarBrandRepository
    {
        private readonly ApplicationDbContext _context;

        public CarBrandRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CarBrand>> GetAllAsync()
        {
            return await _context.CarBrands.ToListAsync();
        }

        public async Task AddAsync(CarBrand entity)
        {
            await _context.CarBrands.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsByNameAsync(string name)
        {
            return await _context.CarBrands
                .AnyAsync(x => x.Name.ToLower() == name.ToLower());
        }
    }
}
