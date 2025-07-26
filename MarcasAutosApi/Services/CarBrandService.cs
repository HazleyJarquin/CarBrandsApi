using AutoMapper;
using FluentValidation;
using MarcasAutosApi.Dtos;
using MarcasAutosApi.Entities;
using MarcasAutosApi.Repositories.Interfaces;
using MarcasAutosApi.Services.Interfaces;

public class CarBrandService : ICarBrandService
{
    private readonly ICarBrandRepository _repo;
    private readonly IValidator<CarBrandDto> _validator;
    private readonly IMapper _mapper;

    public CarBrandService(ICarBrandRepository repo, IValidator<CarBrandDto> validator, IMapper mapper)
    {
        _repo = repo;
        _validator = validator;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CarBrandDto>> GetCarBrandsAsync()
    {
        var entities = await _repo.GetAllAsync();
        return _mapper.Map<IEnumerable<CarBrandDto>>(entities);
    }

    public async Task AddAsync(CarBrandDto dto)
    {
        var validationResult = await _validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
        {
            var errors = string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage));
            throw new ArgumentException($"Error de validación: {errors}");
        }

        var entity = _mapper.Map<CarBrand>(dto);
        await _repo.AddAsync(entity);
    }
}
