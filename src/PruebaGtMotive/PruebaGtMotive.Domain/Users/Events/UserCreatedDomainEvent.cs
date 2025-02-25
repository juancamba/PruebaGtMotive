using PruebaGtMotive.Domain.Abstractions;

namespace PruebaGtMotive.Domain.Users.Events;

public sealed record UserCreatedDomainEvent(UserId UserId) : IDomainEvent;