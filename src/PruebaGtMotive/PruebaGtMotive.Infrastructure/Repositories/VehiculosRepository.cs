using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PruebaGtMotive.Domain.Users;
using PruebaGtMotive.Domain.Vehiculos;

namespace PruebaGtMotive.Infrastructure.Repositories;

internal sealed class VehiculosRepository : Repository<Vehiculo, VehiculoId>, IVehiculoRepository
{
    public VehiculosRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IReadOnlyList<Vehiculo>> GetAllAsync(CancellationToken cancellationToken = default)
    {
            return await DbContext.Set<Vehiculo>()
            .ToListAsync(cancellationToken);
    }

    public async Task<Vehiculo?> GetByIdAsync(VehiculoId id, CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<Vehiculo>()
            .FirstOrDefaultAsync(v => v.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<Vehiculo>> GetDisponiblesAsync(CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<Vehiculo>()
        .Where(v => !v.Alquilado)
        .ToListAsync(cancellationToken);
    }

    public async Task<bool> IsBastidorInDb(string bastidor, CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<Vehiculo>().AnyAsync(v => v.Bastidor == new Bastidor(bastidor));
    }
}
