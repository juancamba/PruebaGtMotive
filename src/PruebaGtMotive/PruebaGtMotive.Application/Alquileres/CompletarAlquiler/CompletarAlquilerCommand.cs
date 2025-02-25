using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaGtMotive.Application.Abstractions.Messaging;

namespace PruebaGtMotive.Application.Alquileres.CompletarAlquiler;

public sealed record CompletarAlquilerCommand(Guid VehiculoId, Guid UserId): ICommand<Guid>;