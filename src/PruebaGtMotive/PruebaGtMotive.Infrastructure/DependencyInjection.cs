
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PruebaGtMotive.Application.Abstractions.Clock;
using PruebaGtMotive.Domain.Abstractions;
using PruebaGtMotive.Domain.Alquileres;
using PruebaGtMotive.Domain.Users;
using PruebaGtMotive.Domain.Vehiculos;
using PruebaGtMotive.Infrastructure.Clock;
using PruebaGtMotive.Infrastructure.Repositories;

namespace PruebaGtMotive.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {

        var connectionString = configuration.GetConnectionString("Database") ?? throw new ArgumentNullException(nameof(configuration));

        services.AddTransient<IDateTimeProvider, DateTimeProvider>();
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IVehiculoRepository, VehiculosRepository>();
        services.AddScoped<IAlquilerRepository, AlquilerRepository>();

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());

        /*services.AddSingleton<ISqlConnectionFactory>( _ => new SqlConnectionFactory(connectionString));
        SqlMapper.AddTypeHandler(new DateOnlyTypeHandler());
        */
        return services;
    }

}
