using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using MarcasAutosApi.Dtos;
using MarcasAutosApi.Entities;
using MarcasAutosApi.Repositories.Interfaces;
using MarcasAutosApi.Services;
using Moq;
using Xunit;
using System.Collections.Generic;
using System.Threading.Tasks;

public class CarBrandServiceTests
{
    private readonly Mock<ICarBrandRepository> _repoMock = new();
    private readonly Mock<IValidator<CarBrandDto>> _validatorMock = new();
    private readonly IMapper _mapper;
    private readonly CarBrandService _service;

    public CarBrandServiceTests()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<CarBrandDto, CarBrand>();
            cfg.CreateMap<CarBrand, CarBrandDto>();
        });

        _mapper = config.CreateMapper();
        _service = new CarBrandService(_repoMock.Object, _validatorMock.Object, _mapper);
    }

    [Fact]
    public async Task AddAsync_Should_Throw_When_Invalid()
    {
        var dto = new CarBrandDto { Name = "" };
        var result = new ValidationResult(new List<ValidationFailure>
        {
            new("Name", "El nombre es obligatorio.")
        });

        _validatorMock.Setup(v => v.ValidateAsync(dto, default)).ReturnsAsync(result);

        await Assert.ThrowsAsync<ArgumentException>(() => _service.AddAsync(dto));
        _repoMock.Verify(r => r.AddAsync(It.IsAny<CarBrand>()), Times.Never);
    }

    [Fact]
    public async Task AddAsync_Should_Save_When_Valid()
    {
        var dto = new CarBrandDto { Name = "Nissan" };
        _validatorMock.Setup(v => v.ValidateAsync(dto, default)).ReturnsAsync(new ValidationResult());

        await _service.AddAsync(dto);

        _repoMock.Verify(r => r.AddAsync(It.Is<CarBrand>(m => m.Name == "Nissan")), Times.Once);
    }

    [Fact]
    public async Task GetCarBrandsAsync_Should_Return_List()
    {
        var list = new List<CarBrand> { new() { Id = 1, Name = "Kia" } };
        _repoMock.Setup(r => r.GetAllAsync()).ReturnsAsync(list);

        var result = await _service.GetCarBrandsAsync();

        Assert.NotNull(result);
        Assert.Single(result);
    }
}
