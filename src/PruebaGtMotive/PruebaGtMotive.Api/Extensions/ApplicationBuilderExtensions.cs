using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Writers;
using PruebaGtMotive.Api.Middleware;
using PruebaGtMotive.Infrastructure;

namespace PruebaGtMotive.Api.Extensions;

public static class ApplicationBuilderExtensions
{
    public static async Task ApplyMigration(this IApplicationBuilder app)
    {

        using(var scope = app.ApplicationServices.CreateScope())
        {
            var service = scope.ServiceProvider;
            var loggerFactory = service.GetRequiredService<ILoggerFactory>();

            try
            {
                var context = service.GetRequiredService<ApplicationDbContext>();
                await context.Database.MigrateAsync();
            }
            catch(Exception ex)
            {
                //sobre Program, porque es quien eejecuta este metodo
                var logger  = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "Error en migracion");
            }
        }
    }

    public static void UseCustomExceptionHandler(this IApplicationBuilder app)
    {
                
        app.UseMiddleware<ExceptionHandlingMiddleware>();
    }
}