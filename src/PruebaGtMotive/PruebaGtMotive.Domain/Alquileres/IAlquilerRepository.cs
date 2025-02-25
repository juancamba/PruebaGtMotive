

using PruebaGtMotive.Domain.Users;
using PruebaGtMotive.Domain.Vehiculos;

namespace PruebaGtMotive.Domain.Alquileres;

public interface IAlquilerRepository
{
    Task<Alquiler?> GetByIdAsync(AlquilerId id, CancellationToken cancellationToken = default);

    Task<Alquiler?> GetAlquilerEnCursoByUserIdAndVehicleId(UserId userId,VehiculoId vehiculoId,  CancellationToken cancellationToken = default);

    Task<bool> IsOverlappingAsync(Vehiculo vehiculo, DateRange duracion, CancellationToken cancellationToken = default);

    Task<bool> IsUserRentingACar(UserId userId, CancellationToken cancellationToken = default);

    void Add(Alquiler alquiler);
}
