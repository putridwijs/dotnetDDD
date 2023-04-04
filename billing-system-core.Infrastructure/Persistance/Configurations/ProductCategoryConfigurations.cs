using billing_system_core.Domain.ProductCategoryAggregate;
using billing_system_core.Domain.ProductCategoryAggregate.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace billing_system_core.Infrastructure.Persistance.Configurations;

public class ProductCategoryConfigurations: IEntityTypeConfiguration<ProductCategory>
{
    public void Configure(EntityTypeBuilder<ProductCategory> builder)
    {
        ConfigureProductCategoryTable(builder);
    }

    private void ConfigureProductCategoryTable(EntityTypeBuilder<ProductCategory> builder)
    {
        builder.ToTable("ProductCategories");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => ProductCategoryId.Create(value)
            );
    }
}