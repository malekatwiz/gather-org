using Gather.Products.Api.Storage.Database;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddFramework()
    .AddDatabase(builder.Configuration)
    .AddServices();
var app = builder.Build();

using var dbContextScope = app.Services.CreateScope();
dbContextScope.ServiceProvider.GetRequiredService<ProductsDbContext>()?.Database.EnsureCreated();

app.MapGet("/", () => "Hello World!");
app.Use(async (context, next) =>
{
    if (context?.Request?.Path.Value?.Contains("/api") == true)
    {
        if (context.Request.Headers.ContainsKey("apikey"))
        {
            var secret = app.Configuration.GetSection("Secrets").GetValue<string>("Key");
            var userKey = context.Request.Headers["apikey"].ToString();
            if (!(secret ?? "mYSEEcret").Equals(userKey))
            {
                await Results.Unauthorized().ExecuteAsync(context);
            }
            await next();
        }
        else
        {
            await Results.Unauthorized().ExecuteAsync(context);
        }
    }
});

app.MapGet("/api", async ([FromQuery] string code) =>
{
    try
    {
        await using var serviceScope = app.Services.CreateAsyncScope();
        var productsProvider = serviceScope.ServiceProvider.GetRequiredService<IProductInfoProvider>();
        var products = await productsProvider.GetByCode(code);
        if (products?.Any() == false)
        {
            return Results.NotFound();
        }

        return Results.Json(products);
    }
    catch(Exception ex)
    {
        return Results.Problem(ex.Message);
    }
});

app.Run();

public partial class Program { }
