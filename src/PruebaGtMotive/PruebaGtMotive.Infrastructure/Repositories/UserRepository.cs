using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using PruebaGtMotive.Domain.Users;

namespace PruebaGtMotive.Infrastructure.Repositories;

internal sealed class UserRepository : Repository<User, UserId>, IUserRepository
{
    public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IReadOnlyList<User>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        // Ejecutar la consulta asíncrona para obtener todos los usuarios
        var users = await DbContext.Set<User>()
                                .ToListAsync(cancellationToken);
        return users;
    }

    public async Task<User?> GetByEmailAsync(Email email, CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<User>().FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
    }

    public async Task<User?> GetByIdAsync(UserId id, CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<User>()
            .FirstOrDefaultAsync(v => v.Id == id, cancellationToken);

    }
    public async Task<bool> IsUserExists(Email email, CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<User>().AnyAsync(x => x.Email == email);
    }
}