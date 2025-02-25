
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.VisualStudio.TestPlatform.TestHost;

using PruebaGtMotive.Infrastructure;
using Testcontainers.MsSql;
using Xunit;

namespace PruebaGtMotive.Application.IntegrationTests;
public class IntegrationTestWebAppFactory : WebApplicationFactory<Program>, IAsyncLifetime
{

    private readonly MsSqlContainer _dbContainer = new MsSqlBuilder()
      .WithImage("mcr.microsoft.com/mssql/server:2019-latest")
      //.WithDatabase("PruebaGtMotivedb")
      //.WithUsername("PruebaGtMotivedb")
      .WithPassword("YourStrong!Passw0rd")
      //.WithPortBinding(1433, true)
      .Build();



    public async Task InitializeAsync()
    {
        //metodo del testcontainer , inicio del test container
        await _dbContainer.StartAsync();
    }

    public new async Task DisposeAsync()
    {
        await _dbContainer.StopAsync();
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
             services.RemoveAll(typeof(DbContextOptions<ApplicationDbContext>));
             services.AddDbContext<ApplicationDbContext>(options =>
             {
                 options.UseSqlServer(_dbContainer.GetConnectionString());
             });



         });


        base.ConfigureWebHost(builder);
    }


}
