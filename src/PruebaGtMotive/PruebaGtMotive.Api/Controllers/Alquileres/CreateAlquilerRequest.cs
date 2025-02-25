using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Api.Controllers.Alquileres;

public sealed record CreateAlquilerRequest(
    Guid VehiculoId, Guid UserId, DateOnly FechaInicio, DateOnly FechaFin
);