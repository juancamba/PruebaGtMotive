

namespace PruebaGtMotive.Domain.Users;

public interface IUserRepository
{
  /*
  Task<User?> GetByIdAsync(UserId id, CancellationToken cancellationToken = default);

  void Add(User user);
*/
  //Task<User?> GetByIdAsync(UserId id, CancellationToken cancellationToken = default);
  Task<IReadOnlyList<User>> GetAllAsync(CancellationToken cancellationToken = default);
  Task<User?> GetByIdAsync(UserId id, CancellationToken cancellationToken = default);
  Task<User?> GetByEmailAsync(Email email, CancellationToken cancellationToken = default);
  Task<bool> IsUserExists(Email email, CancellationToken cancellationToken = default);

   void Add(User user);

}
