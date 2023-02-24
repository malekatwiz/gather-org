using Gather.Products.Api.Storage.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gather.Products.Api.Storage.Database
{
    public class ProductsDbContext : DbContext
    {
        public ProductsDbContext(DbContextOptions<ProductsDbContext> options) : base(options)
        {            
        }

        public DbSet<ProductEntity> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductEntity>(e =>
            {
                e.ToTable("Products");
                e.HasKey(e => e.Id);
                e.Property(p => p.CreatedOn).HasDefaultValue(DateTime.UtcNow);
            });
        }
    }
}
