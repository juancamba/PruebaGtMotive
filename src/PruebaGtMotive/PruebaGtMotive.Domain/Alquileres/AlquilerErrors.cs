

using PruebaGtMotive.Domain.Abstractions;

namespace PruebaGtMotive.Domain.Alquileres;

public static class AlquilerErrors
{
    public static Error NotFound = new Error(
        "Alquiler.Found",
        "El alquiler con el id especificado no fue encontrado"
    );

    //si intentas alquilar un coche que ya fué reservado
    public static Error Overlap = new Error(
        "Alquiler.Overlap",
        "El alquiler está siendo tomado por 2 o mas clientes en la misma fecha"
    );

    public static Error NotReserved = new Error(
        "Alquiler.NotReserved",
        "El alquiler no está reservado"
    );

    public static Error NotConfirmado = new Error(
        "Alquiler.NotConfirmado",
        "El alquiler no está confirmado"
    );

    public static Error YaCompletado = new Error(
        "Alquiler.YaCompletado",
        "El alquiler ya ha sido completado"
    );
}