using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaGtMotive.Api.Controllers.Vehiculos;

public record CreateVehiculoRequest(string Marca, string Modelo, int AnoFabricacion, string bastidor) ;