using System.Net.Http.Json;
using PruebaGtMotive.Api.FunctionalTests.Users;

using PruebaGtMotive.Infrastructure;

using Microsoft.AspNetCore.Hosting;


using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using Testcontainers.MsSql;
using Microsoft.AspNetCore.TestHost;

namespace PruebaGtMotive.Api.FunctionalTests.Infrastructure;


public class FunctionalTestsWebAppFactory : WebApplicationFactory<Program>, IAsyncLifetime
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
        await _dbContainer.StartAsync();

        await CreateUserTestAsync();
    }

    public new async Task DisposeAsync()
    {
        await _dbContainer.StopAsync();
    }

    private async Task CreateUserTestAsync()
    {
        var httpClient = CreateClient();

        await httpClient
        .PostAsJsonAsync("api/Users/register", UserData.RegisterUserRequestTest);
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