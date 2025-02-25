
using PruebaGtMotive.Application.Abstractions.Messaging;

namespace PruebaGtMotive.Application.Users.RegisterUser;
public sealed record RegisterUserCommand(string Email, string Nombre, string Appelidos, string Password) : ICommand<Guid>;
