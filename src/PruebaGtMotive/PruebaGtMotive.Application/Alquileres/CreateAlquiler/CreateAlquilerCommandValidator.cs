using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace PruebaGtMotive.Application.Alquileres.CreateAlquiler;

internal sealed class CreateAlquilerCommandValidator : AbstractValidator<CreateAlquilerCommand>
{
    public CreateAlquilerCommandValidator()
    {
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.VehiculoId).NotEmpty();
        RuleFor(c => c.FechaInicio)
            .LessThan(c => c.FechaFin);
    }
}
