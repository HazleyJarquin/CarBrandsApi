using Xunit;
using Moq;
using MarcasAutosApi.Dtos;
using MarcasAutosApi.Utils.Validators;
using MarcasAutosApi.Repositories.Interfaces;
using FluentValidation.TestHelper;
using System.Threading.Tasks;

public class CarBrandValidatorTests
{
    private readonly Mock<ICarBrandRepository> _repoMock;
    private readonly CarBrandValidator _validator;

    public CarBrandValidatorTests()
    {
        _repoMock = new Mock<ICarBrandRepository>();
        _validator = new CarBrandValidator(_repoMock.Object);
    }

    [Fact]
    public async Task Should_Have_Error_When_Name_Is_Empty()
    {
        var dto = new CarBrandDto { Name = "" };

        var result = await _validator.TestValidateAsync(dto);

        result.ShouldHaveValidationErrorFor(x => x.Name)
              .WithErrorMessage("El nombre es obligatorio.");
    }

    [Fact]
    public async Task Should_Have_Error_When_Name_Already_Exists()
    {
        var dto = new CarBrandDto { Name = "Toyota" };

        _repoMock.Setup(r => r.ExistsByNameAsync("Toyota"))
                 .ReturnsAsync(true);

        var result = await _validator.TestValidateAsync(dto);

        result.ShouldHaveValidationErrorFor(x => x.Name)
              .WithErrorMessage("Ya existe una marca con ese nombre.");
    }

    [Fact]
    public async Task Should_Pass_When_Name_Is_Unique_And_Valid()
    {
        var dto = new CarBrandDto { Name = "Mazda" };

        _repoMock.Setup(r => r.ExistsByNameAsync("Mazda"))
                 .ReturnsAsync(false);

        var result = await _validator.TestValidateAsync(dto);

        result.ShouldNotHaveAnyValidationErrors();
    }
}
