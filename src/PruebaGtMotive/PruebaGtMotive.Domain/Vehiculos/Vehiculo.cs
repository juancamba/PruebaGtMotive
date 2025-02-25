
using PruebaGtMotive.Domain.Abstractions;

namespace PruebaGtMotive.Domain.Vehiculos;

public  class Vehiculo : Entity<VehiculoId>
{
    private Vehiculo(){}
    
    public Vehiculo(VehiculoId id, Marca marca, Modelo modelo, AnoFabricacion? anoFabricacion, Bastidor bastidor): base(id)
    {
        Marca = marca;
        Modelo = modelo;
        
        AnoFabricacion = anoFabricacion;
        Bastidor = bastidor;
    }

    public Marca? Marca { get; private set; }
    public Modelo? Modelo { get; private set; }
    public bool Alquilado { get; internal set; } = false;
    public AnoFabricacion? AnoFabricacion { get; internal set; }

    public Bastidor? Bastidor{get; private set;}
    
    public static Vehiculo Create(Marca marca, Modelo modelo, AnoFabricacion? anoFabricacion, Bastidor bastidor)
    {
        var vehiculo = new Vehiculo(VehiculoId.New(), marca, modelo, anoFabricacion, bastidor);
        return vehiculo;
    }
    public void MarcarComoAlquilado()
    {
        Alquilado = true;
    }
    public void MarcarComoDisponible()
    {
        Alquilado = false;
    }
}
