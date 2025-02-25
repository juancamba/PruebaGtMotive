using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaGtMotive.Domain.Users;

namespace PruebaGtMotive.Infrastructure.Configurations;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");
        builder.HasKey(user => user.Id);

        builder.Property(user => user.Id)
            // primer argumento es entity - > bd, 2 arg es bd -> entity
            .HasConversion(userId => userId!.Value, value => new UserId(value));

        builder.Property(user => user.Nombre)
            .HasMaxLength(200)
            .HasConversion(nombre => nombre!.Value, value => new Nombre(value));


        builder.Property(user => user.Apellido)
            .HasMaxLength(200)
            .HasConversion(apellido => apellido!.Value, value => new Apellido(value));

        builder.Property(user => user.Email)
            .HasMaxLength(400)
            .HasConversion(email => email!.Value, value => new Domain.Users.Email(value));


        builder.Property(user => user.PasswordHash)
            .HasMaxLength(2000)
            .HasConversion(password => password!.Value, value => new PasswordHash(value));

        builder.HasIndex(user => user.Email).IsUnique();

        builder.Property(v => v.Version).IsRowVersion(); 
    }
}
