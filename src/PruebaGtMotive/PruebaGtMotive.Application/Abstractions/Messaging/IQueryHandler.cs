
using PruebaGtMotive.Domain.Abstractions;
using MediatR;

namespace PruebaGtMotive.Application.Abstractions.Messaging;

public interface IQueryHandler<TQuery, TResponse>: IRequestHandler<TQuery, Result<TResponse>> where TQuery : IQuery<TResponse>
{
    
}
