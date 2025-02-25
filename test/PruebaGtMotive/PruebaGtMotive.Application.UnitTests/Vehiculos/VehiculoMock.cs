
using PruebaGtMotive.Domain.Vehiculos;

namespace PruebaGtMotive.Application.UnitTests.Vehiculos;

internal static class VehiculoMock
{

    public static Vehiculo Create()
        => new(
            VehiculoId.New(),
            new Marca("Honda"),
            new Modelo("Civic"),
            new AnoFabricacion(DateTime.UtcNow.Year - 1), // Convertir correctamente
            new Bastidor("45dsdfds5444")
        );

}
//Create(Marca marca, Modelo modelo, AnoFabricacion? anoFabricacion, Bastidor bastidor)