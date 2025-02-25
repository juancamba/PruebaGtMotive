using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaGtMotive.Domain.Alquileres;
using PruebaGtMotive.Domain.Users;
using PruebaGtMotive.Domain.Vehiculos;

namespace PruebaGtMotive.Infrastructure.Configurations;

internal sealed class AlquilerConfiguration : IEntityTypeConfiguration<Alquiler>
{
    public void Configure(EntityTypeBuilder<Alquiler> builder)
    {
        builder.ToTable("alquileres");
        
        builder.Property(alquiler => alquiler.Id)
            // primer argumento es entity - > bd, 2 arg es bd -> entity
            .HasConversion(alquilerId => alquilerId!.Value, value => new AlquilerId(value));


        builder.OwnsOne(alquiler => alquiler.Duracion);

        builder.HasOne<Vehiculo>()
            .WithMany()
            .HasForeignKey(alquiler => alquiler.VehiculoId);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(alquiler => alquiler.UserId);

        builder.Property(v => v.Version).IsRowVersion();
    }
}
