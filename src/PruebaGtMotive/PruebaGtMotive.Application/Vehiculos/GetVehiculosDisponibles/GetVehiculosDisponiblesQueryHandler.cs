using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PruebaGtMotive.Application.Abstractions.Messaging;
using PruebaGtMotive.Domain.Abstractions;
using PruebaGtMotive.Domain.Vehiculos;

namespace PruebaGtMotive.Application.Vehiculos.GetVehiculosDisponibles
{
    internal sealed class GetVehiculosDisponiblesQueryHandler : IQueryHandler<GetVehiculosDisponiblesQuery, IReadOnlyList<VehiculoResponse>>
    {

        private readonly IVehiculoRepository _vehiculosRepository;
        private readonly IMapper _mapper;

        public GetVehiculosDisponiblesQueryHandler(IVehiculoRepository vehiculosRepository, IMapper mapper)
        {
            _vehiculosRepository = vehiculosRepository;
            _mapper = mapper;
        }

        public async Task<Result<IReadOnlyList<VehiculoResponse>>> Handle(GetVehiculosDisponiblesQuery request, CancellationToken cancellationToken)
        {
            var vehiculos = await _vehiculosRepository.GetDisponiblesAsync();
            var vehiculosDisponibles = _mapper.Map<IReadOnlyList<VehiculoResponse>>(vehiculos);

            return vehiculosDisponibles.ToList();

        }
    }

}