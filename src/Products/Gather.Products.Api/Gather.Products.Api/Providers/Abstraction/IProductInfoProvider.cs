using Gather.Products.Api.Providers.Models;

namespace Gather.Products.Api.Providers.Abstraction
{
    public interface IProductInfoProvider
    {
        Task<IEnumerable<ProductInfo>> GetByCode(string code, CancellationToken cancellationToken = default);
    }
}
