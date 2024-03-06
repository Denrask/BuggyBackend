using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace BuggyBackend.IntegrationTests;

public class BasicTests
    : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public BasicTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Theory]
    [InlineData("/testoperator")]
    public async Task TestOperatorEndpointResponseTimeAndSuccessStatus(string url)
    {
        // Arrange
        var client = _factory.CreateClient();
        var stopwatch = new Stopwatch();
        stopwatch.Start();

        // Act
        var response = await client.GetAsync(url);
        stopwatch.Stop();

        // Assert
        response.EnsureSuccessStatusCode(); // Status Code 200-299
        Assert.True(stopwatch.ElapsedMilliseconds <= 1000, "Response time is more than 1 second");
    }
}