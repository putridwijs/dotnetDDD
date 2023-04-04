using billing_system_core.Domain.ProductAggregate;
using billing_system_core.Domain.ProductCategoryAggregate;

using Microsoft.EntityFrameworkCore;

namespace billing_system_core.Infrastructure.Persistance;

public class BillingSystemCoreDBContext : DbContext
{
    public BillingSystemCoreDBContext(DbContextOptions<BillingSystemCoreDBContext> options)
        : base(options)
    {
    }

    public DbSet<ProductCategory> ProductCategories { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfigurationsFromAssembly(typeof(BillingSystemCoreDBContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}