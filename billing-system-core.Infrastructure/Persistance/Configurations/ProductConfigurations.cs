using billing_system_core.Domain.ProductAggregate;
using billing_system_core.Domain.ProductAggregate.ValueObjects;
using billing_system_core.Domain.ProductCategoryAggregate.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace billing_system_core.Infrastructure.Persistance.Configurations;

public class ProductConfigurations: IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        ConfigureProductTable(builder);
    }

    private void ConfigureProductTable(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => ProductId.Create(value));

        builder.Property(m => m.ProductCategoryId)
            .HasConversion(
                id => id.Value,
                value => ProductCategoryId.Create(value));
    }
}