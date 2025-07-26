using MarcasAutosApi.Dtos;
using MarcasAutosApi.Entities;

namespace MarcasAutosApi.Services.Interfaces
{
    public interface ICarBrandService
    {
        Task<IEnumerable<CarBrandDto>> GetCarBrandsAsync();
        Task AddAsync(CarBrandDto dto);
    }
}
