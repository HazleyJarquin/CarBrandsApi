using MarcasAutosApi.Entities;

namespace MarcasAutosApi.Repositories.Interfaces
{
    public interface ICarBrandRepository
    {

        Task<IEnumerable<CarBrand>> GetAllAsync();
    }
}
