using FluentValidation;
using MarcasAutosApi.Dtos;
using MarcasAutosApi.Repositories.Interfaces;

namespace MarcasAutosApi.Utils.Validators
{
    public class CarBrandValidator : AbstractValidator<CarBrandDto>
    {
        public CarBrandValidator(ICarBrandRepository repository)
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .MaximumLength(100).WithMessage("Máximo 100 caracteres.")
                .MustAsync(async (name, cancellation) =>
                {
                    var exists = await repository.ExistsByNameAsync(name);
                    return !exists;
                }).WithMessage("Ya existe una marca con ese nombre.");
        }
    }
}
