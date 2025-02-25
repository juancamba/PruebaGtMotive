using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaGtMotive.Domain.Vehiculos;

public record AnoFabricacion
{
    public int Value{get;}

    public AnoFabricacion(int value)
    {
        if (DateTime.UtcNow.Year - value > 5)
            throw new ApplicationException("El vehículo no puede tener más de 5 años de antigüedad.");
         Value = value;
    }
}
    
