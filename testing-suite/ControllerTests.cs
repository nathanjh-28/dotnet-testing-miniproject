using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Json;
using System.Security.Cryptography.X509Certificates;
using unit_testing_routes_db_miniproject;

namespace testing_suite;

public class ControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    private const string relativePath = "/projects";

    public ControllerTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task Get_Returns_SuccessStatusCode()
    {
        // Arrange
        HttpClient client = _factory.CreateClient();

        // Act
        HttpResponseMessage response = await client.GetAsync(relativePath);

        // Assert    
        Assert.True(response.IsSuccessStatusCode);
    }

    // test get by id response code
    [Theory]
    [InlineData(1, true)]
    [InlineData(0, false)]
    [InlineData(-1, false)]
    public async Task GetById_Returns_CorrectStatusCode(int id, bool isSuccess)
    {
        // Arrange
        HttpClient client = _factory.CreateClient();
        string url = $"{relativePath}/{id}";

        // Act
        HttpResponseMessage response = await client.GetAsync(url);

        // Assert
        if (isSuccess)
        {
            Assert.True(response.IsSuccessStatusCode);
        }
        else
        {
            Assert.False(response.IsSuccessStatusCode);
            Assert.Equal(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
        }
    }


}




