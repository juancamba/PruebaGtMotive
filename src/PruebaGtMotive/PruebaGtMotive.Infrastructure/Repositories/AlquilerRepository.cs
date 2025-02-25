using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PruebaGtMotive.Domain.Alquileres;
using PruebaGtMotive.Domain.Users;
using PruebaGtMotive.Domain.Vehiculos;

namespace PruebaGtMotive.Infrastructure.Repositories;



internal sealed class AlquilerRepository : Repository<Alquiler, AlquilerId>, IAlquilerRepository
{

    private static readonly AlquilerStatus[] ActiveAlquilerStatuses = {

        AlquilerStatus.Alquilado

    };

    public AlquilerRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<Alquiler?> GetAlquilerEnCursoByUserIdAndVehicleId(UserId userId, VehiculoId vehiculoId, CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<Alquiler>()
           .FirstOrDefaultAsync(
               alquiler =>
                   alquiler.UserId == userId &&
                   alquiler.VehiculoId == vehiculoId &&
                   ActiveAlquilerStatuses.Contains(alquiler.Status),
               cancellationToken
           );
    }

    /*public void Add(Alquiler alquiler)
    {
        throw new NotImplementedException();
    }*/

    public Task<Alquiler?> GetByIdAsync(AlquilerId id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> IsOverlappingAsync(Vehiculo vehiculo, DateRange duracion, CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<Alquiler>()
           .AnyAsync(
               alquiler =>
                   alquiler.VehiculoId == vehiculo.Id &&
                   alquiler.Duracion!.Inicio <= duracion.Fin &&
                   alquiler.Duracion.Fin >= duracion.Inicio &&
                   ActiveAlquilerStatuses.Contains(alquiler.Status),
                   cancellationToken
           );
    }

    public async Task<bool> IsUserRentingACar(UserId userId, CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<Alquiler>()
          .AnyAsync(
              alquiler =>
                  /*  alquiler.VehiculoId == vehiculo.Id &&
                    alquiler.Duracion!.Inicio <= duracion.Fin &&
                    alquiler.Duracion.Fin >= duracion.Inicio &&*/
                  alquiler.UserId == userId &&
                  ActiveAlquilerStatuses.Contains(alquiler.Status),
                  cancellationToken
          );
    }
}
