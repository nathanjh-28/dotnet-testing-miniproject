using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Json;
using System.Security.Cryptography.X509Certificates;
using unit_testing_routes_db_miniproject;

namespace testing_suite;

public class UnitTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    private const string relativePath = "/weatherforecast";

    public UnitTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task Get_WeatherForecasts_Returns_SuccessStatusCode()
    {
        // Arrange
        HttpClient client = _factory.CreateClient();

        // Act
        HttpResponseMessage response = await client.GetAsync(relativePath);

        // Assert    
        Assert.True(response.IsSuccessStatusCode);
    }

    [Fact]
    public async Task Get_WeatherForecasts_ReturnsFiveForecasts()
    {
        // Arrange
        HttpClient client = _factory.CreateClient();

        // Act
        HttpResponseMessage response = await client.GetAsync(relativePath);
        WeatherForecast[]? forecasts = await response.Content.ReadFromJsonAsync<WeatherForecast[]>();

        // Assert
        Assert.NotNull(forecasts);
        Assert.True(forecasts.Length == 5);
    }
}