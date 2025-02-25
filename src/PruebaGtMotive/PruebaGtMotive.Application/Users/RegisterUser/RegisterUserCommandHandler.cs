
using PruebaGtMotive.Application.Abstractions.Messaging;
using PruebaGtMotive.Domain.Abstractions;
using PruebaGtMotive.Domain.Users;

namespace PruebaGtMotive.Application.Users.RegisterUser;
internal class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand, Guid>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        // 1. validar que no existe en bd
        Email email = new (request.Email);
        var userExists = await  _userRepository.IsUserExists(email);

        if(userExists)
        {
            return Result.Failure<Guid>(UserErrors.AlreadyExists);
        }

        // 2. encriptar pass

        var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

        // 3 crear un objeto user
        var user = User.Create(
            new Nombre(request.Nombre),
            new Apellido(request.Appelidos),
            new Email(request.Email),
            new PasswordHash(passwordHash)
        );

        // 4 insertar usuario a bd

        _userRepository.Add(user);
        await _unitOfWork.SaveChangesAsync();

        return user.Id!.Value;
        
    }
}
