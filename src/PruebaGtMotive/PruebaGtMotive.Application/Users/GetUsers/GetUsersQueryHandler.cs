using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PruebaGtMotive.Application.Abstractions.Messaging;
using PruebaGtMotive.Domain.Abstractions;
using PruebaGtMotive.Domain.Users;

namespace PruebaGtMotive.Application.Users.GetUsers;



internal sealed class GetUsersQueryHandler : IQueryHandler<GetUsersQuery, IReadOnlyList<UserResponse>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetUsersQueryHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async  Task<Result<IReadOnlyList<UserResponse>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAllAsync();
        var usersResponse = _mapper.Map<IReadOnlyList<UserResponse>>(users);
        return Result.Success(usersResponse);
    }
}
