using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace PruebaGtMotive.Application.Alquileres.CompletarAlquiler;

internal sealed class CompletarAlquilerCommandValidator : AbstractValidator<CompletarAlquilerCommand>
{
    public CompletarAlquilerCommandValidator()
    {
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.VehiculoId).NotEmpty();
        ;
    }
}
