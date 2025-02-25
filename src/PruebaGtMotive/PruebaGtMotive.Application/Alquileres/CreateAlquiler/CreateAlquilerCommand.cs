using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaGtMotive.Application.Abstractions.Messaging;

namespace PruebaGtMotive.Application.Alquileres.CreateAlquiler;

public sealed record CreateAlquilerCommand(Guid VehiculoId, Guid UserId, DateOnly FechaInicio, DateOnly FechaFin) : ICommand<Guid>;