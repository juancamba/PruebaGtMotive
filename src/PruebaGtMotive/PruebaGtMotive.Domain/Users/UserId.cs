using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaGtMotive.Domain.Users;

public record UserId(Guid Value)
{
    public static UserId New() => new (Guid.NewGuid());

}
   
