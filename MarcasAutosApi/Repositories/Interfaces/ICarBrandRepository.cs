using MarcasAutosApi.Entities;
using System.Diagnostics.CodeAnalysis;

namespace MarcasAutosApi.Repositories.Interfaces
{
    public interface ICarBrandRepository
    {

        Task<IEnumerable<CarBrand>> GetAllAsync();
        Task AddAsync(CarBrand entity);
        Task<bool> ExistsByNameAsync(string name);
    }
}
