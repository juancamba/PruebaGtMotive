using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaGtMotive.Application.Abstractions.Clock;
using PruebaGtMotive.Application.Abstractions.Messaging;
using PruebaGtMotive.Domain.Abstractions;
using PruebaGtMotive.Domain.Alquileres;
using PruebaGtMotive.Domain.Users;
using PruebaGtMotive.Domain.Vehiculos;

namespace PruebaGtMotive.Application.Alquileres.CompletarAlquiler;

internal sealed class CompletarAlquilerCommandHandler : ICommandHandler<CompletarAlquilerCommand, Guid>
{
    private readonly IUserRepository _userRepository;
    private readonly IVehiculoRepository _vehiculoRepository;
    private readonly IAlquilerRepository _alquilerRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDateTimeProvider _dateTimeProvider;

    public CompletarAlquilerCommandHandler(IUserRepository userRepository, IVehiculoRepository vehiculoRepository, IAlquilerRepository alquilerRepository, IUnitOfWork unitOfWork, IDateTimeProvider dateTimeProvider)
    {
        _userRepository = userRepository;
        _vehiculoRepository = vehiculoRepository;
        _alquilerRepository = alquilerRepository;
        _unitOfWork = unitOfWork;
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task<Result<Guid>> Handle(CompletarAlquilerCommand request, CancellationToken cancellationToken)
    {
        var userId = new UserId(request.UserId);
        var user = await _userRepository.GetByIdAsync(userId, cancellationToken);

        if (user is null)
        {
            return Result.Failure<Guid>(UserErrors.NotFound);
        }

        var vehiculoId = new VehiculoId(request.VehiculoId);
        var vehiculo = await _vehiculoRepository.GetByIdAsync(vehiculoId, cancellationToken);

        if (vehiculo is null)
        {
            return Result.Failure<Guid>(VehiculoErrors.NotFound);
        }

        var alquiler = await _alquilerRepository.GetAlquilerEnCursoByUserIdAndVehicleId(userId, vehiculoId, cancellationToken);

        if (alquiler is null)
        {
            return Result.Failure<Guid>(AlquilerErrors.NotFound);
        }



        alquiler.Completar(_dateTimeProvider.currentTime);
        vehiculo.MarcarComoDisponible();

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(alquiler.Id!.Value);

    }
}
