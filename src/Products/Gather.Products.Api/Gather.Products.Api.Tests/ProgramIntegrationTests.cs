using System.Net;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;

namespace Gather.Products.Api.Tests;

public class ProgramIntegrationTests : IClassFixture<IntegrationFactory>,
    IDisposable
{
    private readonly IntegrationFactory _factory;
    private readonly WireMockServer _server;

    public ProgramIntegrationTests(IntegrationFactory factory)
    {
        _factory = factory;

        var exampleResponseLocation = Path.Combine(AppContext.BaseDirectory,
            "Resources",
            "barcodelookup-ok-response-example.json");

        var exampleResponse = File.ReadAllText(exampleResponseLocation);
        _server = WireMockServer.Start(8001);
        _server.Given(Request.Create()
            .WithPath("/v3/products"))
            .RespondWith(Response.Create()
            .WithBody(exampleResponse));
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
        var response = await client.GetAsync("/api/?code=123456", CancellationToken.None);

        Assert.NotNull(response);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    private static HttpClient CreateAuthenticatedClient(IntegrationFactory factory)
    {
        var client = factory.CreateClient();
        client.DefaultRequestHeaders.Add("apikey", "test-secret");
        return client;
    }

    public void Dispose()
    {
        if (_server != null) _server.Dispose();
    }
}