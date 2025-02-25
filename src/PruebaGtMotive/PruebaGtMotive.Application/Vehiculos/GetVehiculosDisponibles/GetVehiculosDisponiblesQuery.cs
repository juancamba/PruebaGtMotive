using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using PruebaGtMotive.Application.Abstractions.Messaging;

namespace PruebaGtMotive.Application.Vehiculos.GetVehiculosDisponibles;

public sealed record  GetVehiculosDisponiblesQuery() : IQuery<IReadOnlyList<VehiculoResponse>>;
    
