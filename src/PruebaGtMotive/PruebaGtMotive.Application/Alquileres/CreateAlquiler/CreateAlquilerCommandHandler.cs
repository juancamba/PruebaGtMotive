using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaGtMotive.Application.Abstractions.Clock;
using PruebaGtMotive.Application.Abstractions.Messaging;
using PruebaGtMotive.Application.Exceptions;
using PruebaGtMotive.Domain.Abstractions;
using PruebaGtMotive.Domain.Alquileres;
using PruebaGtMotive.Domain.Users;
using PruebaGtMotive.Domain.Vehiculos;

namespace PruebaGtMotive.Application.Alquileres.CreateAlquiler;

internal sealed class CreateAlquilerCommandHandler : ICommandHandler<CreateAlquilerCommand, Guid>
{
    private readonly IUserRepository _userRepository;
    private readonly IVehiculoRepository _vehiculoRepository;
    private readonly IAlquilerRepository _alquilerRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDateTimeProvider _dateTimeProvider;

    public CreateAlquilerCommandHandler(IUserRepository userRepository, IVehiculoRepository vehiculoRepository, IAlquilerRepository alquilerRepository, IUnitOfWork unitOfWork, IDateTimeProvider dateTimeProvider)
    {
        _userRepository = userRepository;
        _vehiculoRepository = vehiculoRepository;
        _alquilerRepository = alquilerRepository;
        _unitOfWork = unitOfWork;
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task<Result<Guid>> Handle(CreateAlquilerCommand request, CancellationToken cancellationToken)
    {
        var userId = new UserId(request.UserId);
        var user = await _userRepository.GetByIdAsync(userId, cancellationToken);

        if (user is null)
        {
            return Result.Failure<Guid>(UserErrors.NotFound);
        }



        if (await _alquilerRepository.IsUserRentingACar(userId, cancellationToken))
        {
            return Result.Failure<Guid>(UserErrors.AlreadyRentingACar);
        }


        var vehiculoId = new VehiculoId(request.VehiculoId);
        var vehiculo = await _vehiculoRepository.GetByIdAsync(vehiculoId);

        if (vehiculo is null)
        {
            return Result.Failure<Guid>(VehiculoErrors.NotFound);
        }

        var duracion = DateRange.Create(request.FechaInicio, request.FechaFin);

        if (await _alquilerRepository.IsOverlappingAsync(vehiculo, duracion))
        {
            return Result.Failure<Guid>(AlquilerErrors.Overlap);
        }


        try
        {
            var alquiler = Alquiler.Alquilar(
                vehiculo,
                user.Id!,
                duracion,
                _dateTimeProvider.currentTime
            );

            _alquilerRepository.Add(alquiler);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success(alquiler.Id!.Value);
        }
        catch (ConcurrencyException)
        {
            return Result.Failure<Guid>(AlquilerErrors.Overlap);
        }
    }
}
