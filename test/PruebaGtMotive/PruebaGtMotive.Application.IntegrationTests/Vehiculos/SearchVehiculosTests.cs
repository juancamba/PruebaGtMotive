
using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using PruebaGtMotive.Application.Vehiculos.GetVehiculosDisponibles;
using Xunit;

namespace PruebaGtMotive.Application.IntegrationTests.Vehiculos;

public class SearchVehiculos : BaseIntegrationTest
{
    public SearchVehiculos(IntegrationTestWebAppFactory factory) : base(factory)
    {
    }

    [Fact]
    public async Task SearchVehiculos_ShouldReturnNotEmptyList()
    {
        //arrange
            var query = new GetVehiculosDisponiblesQuery();
        //act
            var resultado = await Sender.Send(query);
        //assert

        resultado.Value.Should().NotBeEmpty();
        
    }

   




}