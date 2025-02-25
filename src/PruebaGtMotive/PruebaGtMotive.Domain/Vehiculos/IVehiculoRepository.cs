namespace PruebaGtMotive.Domain.Vehiculos;

public interface IVehiculoRepository
{
    Task<Vehiculo?> GetByIdAsync(VehiculoId id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Vehiculo>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Vehiculo>> GetDisponiblesAsync(CancellationToken cancellationToken = default);

    Task<bool> IsBastidorInDb(string bastidor,CancellationToken cancellationToken = default);    

    void Add(Vehiculo vehiculo);

}
