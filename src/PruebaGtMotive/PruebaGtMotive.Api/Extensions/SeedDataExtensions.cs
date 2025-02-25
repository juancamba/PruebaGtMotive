

using Bogus;
using PruebaGtMotive.Domain.Users;
using PruebaGtMotive.Domain.Vehiculos;
using PruebaGtMotive.Infrastructure;

namespace PruebaGtMotive.Api.Extensions;

public static class SeedDataExtensions
{
    public static void SeedData(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var service = scope.ServiceProvider;
        var loggerFactory = service.GetRequiredService<ILoggerFactory>();

        try
        {
            var context = service.GetRequiredService<ApplicationDbContext>();

            var faker = new Faker();

            if (!context.Set<Vehiculo>().Any())
            {
                for (int i = 0; i < 12; i++)
                {
                    var vehiculo = Vehiculo.Create(
                        new Marca(faker.Vehicle.Manufacturer()),
                        new Modelo(faker.Vehicle.Model()),
                        new AnoFabricacion(DateTime.Now.Year),
                        new Bastidor(faker.Vehicle.Vin())
                    );
                    context.Add(vehiculo);
                }
                context.SaveChangesAsync().Wait();
            }

        }
        catch (Exception ex)
        {
            var logger = loggerFactory.CreateLogger<ApplicationDbContext>();
            logger.LogError(ex.Message);
        }

    }

     public static void SeedDataUsers(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();

        var service = scope.ServiceProvider;
        var loggerFactory = service.GetRequiredService<ILoggerFactory>();

        try
        {
            var context = service.GetRequiredService<ApplicationDbContext>();
            if(!context.Set<User>().Any())
            {
                var passwordHash = BCrypt.Net.BCrypt.HashPassword("test1234");
                var user = User.Create(
                    new Nombre("juan"),
                    new Apellido("camba"),
                    new Email("juan@juan.com"),
                    new PasswordHash(passwordHash)

                );
                context.Add(user);
                
                var passwordHash1 = BCrypt.Net.BCrypt.HashPassword("test1234");
                var user1 = User.Create(
                    new Nombre("admin"),
                    new Apellido("admin"),
                    new Email("admin@juan.com"),
                    new PasswordHash(passwordHash1)

                );


            
                context.Add(user1);
                context.SaveChangesAsync().Wait();
            }

        }
        catch (Exception ex)
        {
            
            var logger = loggerFactory.CreateLogger<ApplicationDbContext>();
            logger.LogError(ex.Message);
        }
    }


}