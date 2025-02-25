using PruebaGtMotive.Domain.Abstractions;

namespace PruebaGtMotive.Domain.Vehiculos
{
    public static class VehiculoErrors
    {
        public static Error NotFound = new("Vehiculo.Found", "No existe el vehiculo con ese id");
        public static Error TooOld = new("Vehiculo.TooOld", "No se pueden dar de alta vehiculos con mas de 5 años de antiguedad");

        public static Error BastidorAlreadyExists = new("Vehiculo.BastidorAlreadyExists", "Ya existe un vehiculo con ese bastidor");


    }
}