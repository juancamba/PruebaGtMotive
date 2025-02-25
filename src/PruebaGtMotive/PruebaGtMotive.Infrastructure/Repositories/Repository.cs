
using Microsoft.EntityFrameworkCore;
using PruebaGtMotive.Domain.Abstractions;

namespace PruebaGtMotive.Infrastructure.Repositories;

internal abstract class Repository<TEntity, TEntityId>
//TEntity debe ser una clase que hereda de Entity<TEntityId>. Esto implica que TEntity tiene al menos una propiedad Id del tipo TEntityId.
where TEntity : Entity<TEntityId>
//TEntityId debe ser una clase (por ejemplo, string, Guid, o cualquier tipo de referencia), no un tipo primitivo como int o float.
where TEntityId : class
{
    protected readonly ApplicationDbContext DbContext;

    protected Repository(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public async Task<TEntity?> GetByIdAync(TEntityId id, CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<TEntity>()
            
            .FirstOrDefaultAsync( x => x.Id == id, cancellationToken);
    }

    public void Add(TEntity entity)
    {
        DbContext.Add(entity);
    }
}
