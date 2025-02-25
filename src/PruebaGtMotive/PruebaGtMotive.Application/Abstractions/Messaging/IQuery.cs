
using PruebaGtMotive.Domain.Abstractions;
using MediatR;

namespace PruebaGtMotive.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
    
}
