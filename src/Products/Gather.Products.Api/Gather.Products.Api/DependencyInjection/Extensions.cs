using Gather.Products.Api.Providers;

namespace Gather.Products.Api.DependencyInjection
{
    public static class Extensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services.AddHttpClient(nameof(ExternalProductInfoProvider)).Services
                .AddScoped<IProductInfoProvider, ExternalProductInfoProvider>();
        }

        public static IServiceCollection AddFramework(this IServiceCollection services)
        {
            return services.AddControllers()
                .AddNewtonsoftJson().Services;
        }
    }
}
