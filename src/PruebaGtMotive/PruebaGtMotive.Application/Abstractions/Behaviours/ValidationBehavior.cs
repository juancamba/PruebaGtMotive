

using System.ComponentModel.DataAnnotations;

using FluentValidation;
using MediatR;
using PruebaGtMotive.Application.Abstractions.Messaging;
using PruebaGtMotive.Application.Exceptions;

namespace PruebaGtMotive.Application.Abstractions.Behaviors;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IBaseCommand
{
    
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if(!_validators.Any()) // sino hay ninguna validacion, sino hay errores
        {
            return await next();
        }

        var context = new ValidationContext<TRequest>(request);

       var validationErrors= _validators
        .Select(validators => validators.Validate(context))
        .Where(validationResult => validationResult.Errors.Any())
        .SelectMany(validationResult => validationResult.Errors)
        //por cada error, genero un validateerror
        .Select(validationFailure => new ValidationError(
            validationFailure.PropertyName,
            validationFailure.ErrorMessage
        )).ToList() ;

        if(validationErrors.Any())
        {
            throw new Exceptions.ValidationException(validationErrors);
        }

        return await next();
    }
}
