namespace Gather.Inventory.App.Products;
public class ProductModel
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public string Brand { get; set; }
    public string Weight { get; set; }
    public string Size { get; set; }
    public string BarCode { get; set; }
    public List<string> Images { get; set; }
    public string DefaultImage { get; set; }
}
