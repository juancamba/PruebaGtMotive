using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using PruebaGtMotive.Api.FunctionalTests.Users;
using FluentAssertions;

using Xunit;
using PruebaGtMotive.Api.FunctionalTests.Infrastructure;
using PruebaGtMotive.Application.Users.RegisterUser;

namespace PruebaGtMotive.Api.FunctionalTests.Users;

public class GetUserSessionTests : BaseFunctionalTest
{
	public GetUserSessionTests(FunctionalTestsWebAppFactory factory) : base(factory)
	{
	}

	

	[Fact]
	public async Task Register_ShouldReturnOk_WhenRequestsIsValid()
	{
		//arrange
		var request = new RegisterUserRequest(
				"testx@test.com",
				"testx",
				"testx",
				"Test11233##"
			);


		//act
		var response = await HttpClient.PostAsJsonAsync("api/Users/register", request);


		//assert
		response.StatusCode.Should().Be(HttpStatusCode.OK);

	}

	
	[Fact]
	public async Task Register_ShouldReturnNok_WhenEmailIsDuplicated()
	{
		//arrange
		var request = UserData.RegisterUserRequestTest;		// usuario ya registrado

		//act
		var response = await HttpClient.PostAsJsonAsync("api/Users/register", request);


		//assert
		response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

	}



}