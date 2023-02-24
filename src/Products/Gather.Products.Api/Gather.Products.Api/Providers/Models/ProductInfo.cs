namespace Gather.Products.Api.Providers.Models
{
    public class ProductInfo
    {
        [JsonProperty("title")]
        public string Title { get; set; } = string.Empty;

        [JsonProperty("description")]
        public string Description { get; set; } = string.Empty;

        [JsonProperty("barcode_number")]
        public string BarCode { get; set; } = string.Empty;

        [JsonProperty("images")]
        public List<string> Images { get; set; } = new();

        [JsonProperty("size")]
        public string Size { get; set; } = string.Empty;

        [JsonProperty("category")]
        public string Category { get; set; } = string.Empty;

        [JsonProperty("brand")]
        public string Brand { get; set; } = string.Empty;

        [JsonProperty("weight")]
        public string Weight { get; set; } = string.Empty;
    }
}
