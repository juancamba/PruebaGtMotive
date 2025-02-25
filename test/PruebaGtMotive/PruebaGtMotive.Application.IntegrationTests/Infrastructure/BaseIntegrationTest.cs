
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PruebaGtMotive.Infrastructure;
using Xunit;

namespace PruebaGtMotive.Application.IntegrationTests;

public abstract class BaseIntegrationTest : IClassFixture<IntegrationTestWebAppFactory>
{

    private readonly IServiceScope _scope;
    protected readonly ISender Sender;
    
    protected readonly ApplicationDbContext dbContext;

    protected BaseIntegrationTest(IntegrationTestWebAppFactory factory)
    {
        _scope = factory.Services.CreateScope();
        Sender = _scope.ServiceProvider.GetRequiredService<ISender>();
        dbContext = _scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    }
}