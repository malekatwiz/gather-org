using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;

namespace Gather.Products.Api.Tests
{
    public class IntegrationFactory : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureAppConfiguration(webBuilder => 
            webBuilder.AddInMemoryCollection(
                new List<KeyValuePair<string, string?>>
                {
                    new("Secrets:Key", "test-secret"),
                    new("Secrets:BarCodeApiKey", "api-key"),
                    new("BarcodeLookupApi:Host", "localhost"),
                    new("BarcodeLookupApi:Path", "/v3/products"),
                    new("BarcodeLookupApi:Port", "8001"),
                    new("BarcodeLookupApi:Scheme", "HTTP"),
                }));
            base.ConfigureWebHost(builder);
        }
    }
}
