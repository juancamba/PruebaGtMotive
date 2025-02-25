
using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using PruebaGtMotive.Application.Abstractions.Behaviors;

namespace PruebaGtMotive.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        
        services.AddMediatR(configuration =>{
            configuration.RegisterServicesFromAssemblies(typeof(DependencyInjection).Assembly);
            //configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));
            configuration.AddOpenBehavior(typeof(ValidationBehavior<,>));

        });
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        
        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);
        //services.AddTransient<PrecioService>();
        return services;
    }
}
