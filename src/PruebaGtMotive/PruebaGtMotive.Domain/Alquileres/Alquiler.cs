

using PruebaGtMotive.Domain.Abstractions;
using PruebaGtMotive.Domain.Alquileres.Events;
using PruebaGtMotive.Domain.Users;
using PruebaGtMotive.Domain.Vehiculos;

namespace PruebaGtMotive.Domain.Alquileres;

public sealed class Alquiler : Entity<AlquilerId>
{
    private Alquiler(){}
    
    private Alquiler( AlquilerId id, VehiculoId vehiculoId, UserId userId, DateRange? duracion, AlquilerStatus status, DateTime? fechaCreacion): base(id)
    {
        VehiculoId = vehiculoId;
        UserId = userId;
        Duracion = duracion;
        Status = status;
        FechaCreacion = fechaCreacion;
        
    }

    public VehiculoId? VehiculoId { get; private set; }
    public UserId? UserId { get; private set; }
    public DateRange? Duracion { get; private set; }
    public AlquilerStatus Status { get; private set; }
    public DateTime? FechaCreacion { get; private set; }
    public DateTime? FechaCompletado { get; private set; }


    public static Alquiler Alquilar( Vehiculo vehiculo, UserId userId, DateRange? duracion,DateTime fechaCreacion)
    {
        var alquiler = new Alquiler(AlquilerId.New(), vehiculo.Id!, userId, duracion, AlquilerStatus.Alquilado, fechaCreacion);
        vehiculo.MarcarComoAlquilado(); 
        alquiler.RaiseDomainEvent(new AlquilerConfirmadoDomainEvent(alquiler.Id!));
        return alquiler;
    }



    public Result Completar(DateTime utcNow)
    {
        if(Status != AlquilerStatus.Alquilado)
        {
            return Result.Failure(AlquilerErrors.YaCompletado);
        }

        Status = AlquilerStatus.Completado;
        FechaCompletado = utcNow;

        RaiseDomainEvent(new AlquilerCompletadoDomainEvent(Id!));
        return Result.Success();
    }
}

