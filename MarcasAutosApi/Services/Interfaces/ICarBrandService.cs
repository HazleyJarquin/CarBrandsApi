using MarcasAutosApi.Entities;

namespace MarcasAutosApi.Services.Interfaces
{
    public interface ICarBrandService
    {
        Task<IEnumerable<CarBrand>> GetCarBrandsAsync();
    }
}
