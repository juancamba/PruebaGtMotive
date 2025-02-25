using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaGtMotive.Domain.Vehiculos;

namespace PruebaGtMotive.Application.Vehiculos.GetVehiculosDisponibles;

public class VehiculoResponse
{
    public Guid Id { get; init; }
    public string Marca { get; init; } = string.Empty;
    public string Modelo { get; init; } = string.Empty;
    public int AnoFabricacion { get; init; }
    public bool Alquilado { get; init; }
    public string Bastidor {get; init;}= string.Empty;
}