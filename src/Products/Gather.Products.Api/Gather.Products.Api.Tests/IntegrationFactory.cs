using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;

namespace Gather.Products.Api.Tests
{
    public class IntegrationFactory : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureAppConfiguration(webBuilder => webBuilder.AddInMemoryCollection(
                new List<KeyValuePair<string, string?>>
                {
                    new("Secrets:BarCodeApiKey", "api_secret")
                }));
            base.ConfigureWebHost(builder);
        }
    }
}
