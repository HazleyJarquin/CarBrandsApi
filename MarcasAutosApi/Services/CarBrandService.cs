using MarcasAutosApi.Entities;
using MarcasAutosApi.Repositories.Interfaces;
using MarcasAutosApi.Services.Interfaces;

namespace MarcasAutosApi.Services
{
    public class CarBrandService : ICarBrandService
    {
        private readonly ICarBrandRepository _repo;

        public CarBrandService(ICarBrandRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<CarBrand>> GetCarBrandsAsync()
        {
            return await _repo.GetAllAsync();
        }
    }
}
