using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaGtMotive.Domain.Vehiculos;

namespace PruebaGtMotive.Infrastructure.Configurations;

internal sealed class VehiculoConfiguration : IEntityTypeConfiguration<Vehiculo>
{
    public void Configure(EntityTypeBuilder<Vehiculo> builder)
    {
        builder.ToTable("vehiculos");
        builder.HasKey(vehiculo => vehiculo.Id);

        builder.Property(vehiculo => vehiculo.Id)
              // primer argumento es entity - > bd, 2 arg es bd -> entity
            .HasConversion(vehiculoId => vehiculoId!.Value, value => new VehiculoId(value));

        builder.Property(v => v.Modelo)
            .HasMaxLength(200)
            .HasConversion(modelo => modelo!.Value, value => new Modelo(value)) // se almacena en el cmpo modelo como string de vehiculo en bd, pero en obj son distintos en c#
            ;

        builder.Property(v => v.Marca)
           .HasMaxLength(200)
           .HasConversion(marca => marca!.Value, value => new Marca(value)) // se almacena en el cmpo modelo como string de vehiculo en bd, pero en obj son distintos en c#
           ;

        builder.Property(v => v.Bastidor)
           .HasMaxLength(200)
           .HasConversion(bastidor => bastidor!.Value, value => new Bastidor(value))
           ;

        builder.Property(v => v.AnoFabricacion)
            .HasConversion(anoFabricacion => anoFabricacion!.Value, value => new AnoFabricacion(value)) // se almacena en el cmpo modelo como string de vehiculo en bd, pero en obj son distintos en c#
            .IsRequired()
            ;

        builder.Property(v => v.Alquilado)
            .HasDefaultValue(false);


        builder.Property(v => v.Version).IsRowVersion(); // EF Core manejará automáticamente la columna Version
    }
}
