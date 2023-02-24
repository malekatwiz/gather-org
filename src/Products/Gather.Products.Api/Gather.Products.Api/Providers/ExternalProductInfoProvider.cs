using Gather.Products.Api.Providers.Models;
using Newtonsoft.Json.Linq;

namespace Gather.Products.Api.Providers
{
    public class ExternalProductInfoProvider : IProductInfoProvider
    {
        private readonly HttpClient _httpClient;
        private readonly string _apikey;
        private readonly string _scheme;
        private readonly string _host;
        private readonly string _path;
        private readonly int _port;

        public ExternalProductInfoProvider(IHttpClientFactory httpClientFactory,
            IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient(name: nameof(ExternalProductInfoProvider));
            _apikey = configuration.GetSection("Secrets").GetValue<string>("BarCodeApiKey");
            ArgumentNullException.ThrowIfNull(_apikey, "API Key not found");

            _host = configuration.GetSection("BarcodeLookupApi").GetValue<string>("Host");
            ArgumentNullException.ThrowIfNull(_host, "BarCodeApi Host not found");

            _path = configuration.GetSection("BarcodeLookupApi").GetValue<string>("Path");
            ArgumentNullException.ThrowIfNull(_path, "BarCodeApi Path not found");

            _scheme = configuration.GetSection("BarcodeLookupApi").GetValue<string>("Scheme");
            ArgumentNullException.ThrowIfNull(_scheme, "BarCodeApi Scheme not found");

            _port = configuration.GetSection("BarcodeLookupApi").GetValue<int>("Port");
            ArgumentNullException.ThrowIfNull(_port, "BarCodeApi Port not found");
        }

        public async Task<IEnumerable<ProductInfo>> GetByCode(string code, CancellationToken cancellationToken = default)
        {
            ArgumentException.ThrowIfNullOrEmpty(nameof(code));

            var uri = new UriBuilder
            {
                Scheme = _scheme,
                Host = _host,
                Port = _port,
                Path = _path,
                Query = $"barcode={code}&formatted=y&key={_apikey}"
            }.Uri;

            var response = await _httpClient.GetAsync(uri, cancellationToken);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync(cancellationToken);
            var payload = JsonConvert.DeserializeObject<JObject>(responseContent);
            if (payload?.ContainsKey("products") == false)
            {
                return default;
            }
            return payload["products"].ToObject<List<ProductInfo>>();
        }
    }
}
