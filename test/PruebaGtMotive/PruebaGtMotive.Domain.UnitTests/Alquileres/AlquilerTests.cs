using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using PruebaGtMotive.Domain.Alquileres;
using PruebaGtMotive.Domain.Alquileres.Events;
using PruebaGtMotive.Domain.UnitTests.Infrastructure;
using PruebaGtMotive.Domain.UnitTests.Users;
using PruebaGtMotive.Domain.UnitTests.Vehiculos;
using PruebaGtMotive.Domain.Users;
using PruebaGtMotive.Domain.Vehiculos;
using Xunit;

namespace PruebaGtMotive.Domain.UnitTests.Alquileres
{
    public class AlquilerTests : BaseTest
    {
        [Fact]
        public void Create_Should_RaiseAlquilerConfirmadoDomainEvent()
        {

            var user = User.Create(
                UserMock.Nombre,
                UserMock.Apellido,
                UserMock.Email,
                UserMock.Password
            );



            var vehiculo = VehiculoMock.Create();

            var duracion = DateRange.Create(
                     new DateOnly(2024, 1, 1),
                     new DateOnly(2025, 1, 1)
                 );

            //Act
            var alquiler = Alquiler.Alquilar(
                vehiculo,
                user.Id!,
                duracion,
                DateTime.UtcNow

            );

            // Assert

        var alquilerReservaDomainEvent =  AssertDomainEventWasPublished<AlquilerConfirmadoDomainEvent>(alquiler);

        alquilerReservaDomainEvent.alquilerId.Should().Be(alquiler.Id);

        }
    }
}