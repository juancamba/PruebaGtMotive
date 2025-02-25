using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PruebaGtMotive.Application.Vehiculos.GetVehiculosDisponibles;
using PruebaGtMotive.Domain.Vehiculos;

namespace PruebaGtMotive.Application.Mappping
{
    public sealed class VehiculoProfile : Profile
    {
        public VehiculoProfile()
        {
            CreateMap<Vehiculo, VehiculoResponse>()
                .ForMember(dest => dest.Marca, opt => opt.MapFrom(src => src.Marca!.Value))
                .ForMember(dest => dest.Modelo, opt => opt.MapFrom(src => src.Modelo!.Value))
                .ForMember(dest => dest.Bastidor, opt => opt.MapFrom(src => src.Bastidor!.Value))
                .ForMember(dest => dest.AnoFabricacion, opt => opt.MapFrom(src => src.AnoFabricacion!.Value))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id!.Value));
                ;

            
        }
    }
}