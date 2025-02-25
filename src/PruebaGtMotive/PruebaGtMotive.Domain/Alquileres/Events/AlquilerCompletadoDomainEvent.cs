using PruebaGtMotive.Domain.Abstractions;

namespace PruebaGtMotive.Domain.Alquileres.Events;

public sealed record AlquilerCompletadoDomainEvent(AlquilerId alquilerId) : IDomainEvent;