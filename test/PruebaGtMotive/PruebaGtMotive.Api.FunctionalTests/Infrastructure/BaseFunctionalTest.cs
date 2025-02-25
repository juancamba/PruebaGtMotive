using System.Configuration;
using System.Net.Http.Json;
using PruebaGtMotive.Api.FunctionalTests.Users;

using Xunit;

namespace PruebaGtMotive.Api.FunctionalTests.Infrastructure;

public abstract class BaseFunctionalTest : IClassFixture<FunctionalTestsWebAppFactory>
{

    protected readonly HttpClient HttpClient;

    protected BaseFunctionalTest(FunctionalTestsWebAppFactory factory)
    {
        HttpClient = factory.CreateClient();
    }

  



}