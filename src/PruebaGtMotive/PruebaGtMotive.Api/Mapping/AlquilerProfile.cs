using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Api.Controllers.Alquileres;
using PruebaGtMotive.Application.Alquileres.CreateAlquiler;

namespace PruebaGtMotive.Api.Mapping
{
    public class AlquilerProfile :Profile
    {
        public AlquilerProfile()
        {
            CreateMap<CreateAlquilerRequest, CreateAlquilerCommand>();
        }
    }
}