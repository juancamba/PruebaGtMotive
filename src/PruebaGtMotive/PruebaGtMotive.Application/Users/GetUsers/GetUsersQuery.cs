using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaGtMotive.Application.Abstractions.Messaging;

namespace PruebaGtMotive.Application.Users.GetUsers;

public sealed record  GetUsersQuery(): IQuery<IReadOnlyList<UserResponse>>;