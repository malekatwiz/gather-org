using Gather.Products.Api.Providers;
using Gather.Products.Api.Storage.Database;
using Microsoft.EntityFrameworkCore;

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

        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddDbContext<ProductsDbContext>(o =>
            {
                if ((configuration.GetValue<string>("ASPNETCORE_ENVIRONMENT") ?? "") != "Production")
                {
                    o.UseInMemoryDatabase("ProductsDb");
                }
                else
                {
                    o.UseSqlServer(configuration.GetConnectionString("ProductsDb"));
                }
                o.EnableDetailedErrors();
                o.EnableSensitiveDataLogging();
            });
        }
    }
}
