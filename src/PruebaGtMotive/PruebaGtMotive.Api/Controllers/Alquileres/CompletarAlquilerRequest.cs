using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaGtMotive.Api.Controllers.Alquileres;
public sealed record CompletarAlquilerRequest(Guid VehiculoId, Guid UserId);

