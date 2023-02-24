using System.Net;

namespace Gather.Products.Api.Tests;

public class ProgramIntegrationTests : IClassFixture<IntegrationFactory>
{
    private readonly IntegrationFactory _factory;

    public ProgramIntegrationTests(IntegrationFactory factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task OnApiWithNoApiKey_ReturnsUnauthorized()
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync("/api", CancellationToken.None);

        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    [Fact]
    public async Task OnApiWithEmptyCode_ReturnsBadRequest()
    {
        var client = CreateAuthenticatedClient(_factory);
        var response = await client.GetAsync("/api", CancellationToken.None);

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task OnApiWithNoneExistingCode_ReturnsNotFound()
    {
        var client = CreateAuthenticatedClient(_factory);
        var response = await client.GetAsync("/api/?code={123456}", CancellationToken.None);

        Assert.NotNull(response);
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    private static HttpClient CreateAuthenticatedClient(IntegrationFactory factory)
    {
        var client = factory.CreateClient();
        client.DefaultRequestHeaders.Add("apikey", "mYSEEcret");
        return client;
    }
}