
using AutoMapper;
using PruebaGtMotive.Application.Abstractions.Messaging;
using PruebaGtMotive.Domain.Abstractions;
using PruebaGtMotive.Domain.Vehiculos;

namespace PruebaGtMotive.Application.Vehiculos.CreateVehiculos;

internal sealed class CreateVehiculoCommandHandler : ICommandHandler<CreateVehiculoCommand, Guid>
{

    private readonly IVehiculoRepository _vehiculoRepository;
    private readonly IUnitOfWork _unitOfWork;
    // private readonly IMapper _mapper;

    public CreateVehiculoCommandHandler(IVehiculoRepository vehiculoRepository, IUnitOfWork unitOfWork)
    {
        _vehiculoRepository = vehiculoRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(CreateVehiculoCommand request, CancellationToken cancellationToken)
    {

        var existsBastidor = await _vehiculoRepository.IsBastidorInDb(request.bastidor);
        if (existsBastidor)
        {
            return Result.Failure<Guid>(VehiculoErrors.BastidorAlreadyExists);
        }

        var vehiculo = Vehiculo.Create(
            new Marca(request.Marca),
            new Modelo(request.Modelo),
            new AnoFabricacion(request.AnoFabricacion),
            new Bastidor(request.bastidor)

        );
        _vehiculoRepository.Add(vehiculo);
        await _unitOfWork.SaveChangesAsync();
        return vehiculo.Id!.Value;
    }
}
