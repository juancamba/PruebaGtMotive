
using PruebaGtMotive.Domain.Abstractions;

namespace PruebaGtMotive.Domain.Alquileres.Events;

public sealed record AlquilerConfirmadoDomainEvent(AlquilerId alquilerId) : IDomainEvent;
