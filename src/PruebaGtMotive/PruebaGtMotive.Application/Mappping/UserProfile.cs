using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PruebaGtMotive.Application.Users.GetUsers;
using PruebaGtMotive.Domain.Users;

namespace PruebaGtMotive.Application.Mappping
{
    public sealed class  UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserResponse>()
             .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre!.Value))
             .ForMember(dest => dest.Apellido, opt => opt.MapFrom(src => src.Apellido!.Value))
             .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email!.Value))
             .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id!.Value));
             ;

      
        }
    }
}