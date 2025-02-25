

using FluentValidation;

namespace PruebaGtMotive.Application.Vehiculos.CreateVehiculos;

public class CreateVehiculoCommandValidator : AbstractValidator<CreateVehiculoCommand>
{
    public CreateVehiculoCommandValidator()
    {
        RuleFor(c => c.Modelo)
            .NotEmpty().WithMessage("El modelo es obligatorio.");

        RuleFor(c => c.Marca)
            .NotEmpty().WithMessage("La marca es obligatoria.");

        RuleFor(c => c.AnoFabricacion)
            .GreaterThanOrEqualTo(DateTime.Now.Year - 5)
            .WithMessage($"El vehículo no puede tener más de 5 años de antigüedad. Año mínimo permitido: {DateTime.Now.Year - 5}.");

        RuleFor(c => c.bastidor)
            .NotEmpty().WithMessage("El bastidor es obligatorio.");
    }
}
