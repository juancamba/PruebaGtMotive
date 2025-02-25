

using PruebaGtMotive.Domain.Users;

namespace PruebaGtMotive.Application.UnitTests.Users;

internal static class UserMock
{
    public static User Create() => User.Create(
            Nombre,
            Apellido,
            Email,
            Password
        );

    public static readonly Nombre Nombre = new Nombre("Alfonso");
    public static readonly Apellido Apellido = new Apellido("Ramos");
    public static readonly Email Email = new Email("alfonso.ramos@gmail.com");
    public static readonly PasswordHash Password = new("Test234Test4%");


}