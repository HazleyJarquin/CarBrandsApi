using MarcasAutosApi.Data;
using MarcasAutosApi.Entities;
using MarcasAutosApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore; 
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
    }
}
