using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PruebaGtMotive.Api.Controllers;
using PruebaGtMotive.Api.Controllers.Alquileres;
using PruebaGtMotive.Api.Controllers.Vehiculos;
using PruebaGtMotive.Application.Alquileres.CompletarAlquiler;
using PruebaGtMotive.Application.Vehiculos.CreateVehiculos;

namespace PruebaGtMotive.Api.Mapping;

public sealed class VehiculoProfile : Profile
{
    public VehiculoProfile()
    {
        CreateMap<CreateVehiculoRequest, CreateVehiculoCommand>();
        CreateMap<CompletarAlquilerRequest, CompletarAlquilerCommand>();

    }
}
