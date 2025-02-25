using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using PruebaGtMotive.Application.Abstractions.Messaging;

namespace PruebaGtMotive.Application.Vehiculos.CreateVehiculos;

public record CreateVehiculoCommand(string Marca, string Modelo, int AnoFabricacion, string bastidor) : ICommand<Guid>;


