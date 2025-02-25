using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaGtMotive.Domain.Alquileres;

public record AlquilerId(Guid Value)
{
    public static AlquilerId New() => new(Guid.NewGuid());
}
