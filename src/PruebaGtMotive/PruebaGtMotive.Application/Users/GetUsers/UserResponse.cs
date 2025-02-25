using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaGtMotive.Application.Users.GetUsers;

public sealed class UserResponse
{

    public Guid Id { get; init; }
    public string? Email { get; set; }
    public string? Nombre { get; set; }
    public string? Apellido { get; set; }

}
