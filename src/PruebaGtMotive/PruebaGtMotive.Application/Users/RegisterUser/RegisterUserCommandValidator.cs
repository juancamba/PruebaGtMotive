
using FluentValidation;

namespace PruebaGtMotive.Application.Users.RegisterUser;

internal sealed class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(c => c.Nombre).NotEmpty().WithMessage("El nombre no puede ser null");
        RuleFor(c => c.Appelidos).NotEmpty().WithMessage("Los apellido no puede ser null");
        RuleFor(c => c.Email).EmailAddress().WithMessage("Email no válido"); 
        RuleFor(c => c.Password).NotEmpty().MinimumLength(5);

    }
    
}
