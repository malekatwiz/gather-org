using Gather.Products.Api.Providers.Models;

namespace Gather.Products.Api.Providers
{
    public class ExternalProductInfoProvider : IProductInfoProvider
    {
        private readonly HttpClient _httpClient;
        private readonly string _apikey;

        public ExternalProductInfoProvider(IHttpClientFactory httpClientFactory,
            IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient(name: nameof(ExternalProductInfoProvider));
            _apikey = configuration.GetSection("Secrets").GetValue<string>("BarCodeApiKey");
            ArgumentNullException.ThrowIfNull(_apikey, "API Key not found");
        }

        public async Task<IEnumerable<ProductInfo>> GetByCode(string code, CancellationToken cancellationToken = default)
        {
            ArgumentException.ThrowIfNullOrEmpty(nameof(code));

            var response = await _httpClient.GetAsync($"https://api.barcodelookup.com/v3/products?barcode={code}&formatted=y&key={_apikey}", cancellationToken);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonConvert.DeserializeObject<ProductInfo[]>(responseContent);
        }
    }
}
