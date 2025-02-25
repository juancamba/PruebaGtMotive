using PruebaGtMotive.Domain.Abstractions;

namespace PruebaGtMotive.Domain.Users;

public static class UserErrors
{

    public static Error NotFound = new(
        "User.Found",
        "No existe el usuario buscado por este id"
    );

    public static Error InvalidCredentials = new(
        "User.InvalidCredentials",
        "Las credenciales son incorrectas"
    );

    public static Error AlreadyExists = new(
       "User.AlreadyExists",
       "El usuario ya existe en base de datos"
    );

    public static Error AlreadyRentingACar = new(
       "User.AlreadyRentingACar",
       "El usuario ya está alqulando un coche"
    );

}