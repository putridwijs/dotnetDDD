using billing_system_core.Application.Products.Command;
using billing_system_core.Contracts.Product;
using billing_system_core.Domain.ProductAggregate;

using Mapster;

namespace billing_system_core.Api.Common.Mapping;

public class ProductMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateProductRequest, CreateProductCommand>();
        config.NewConfig<Product, ProductResponse>()
            .Map(dest => dest.Id, src => src.Id.Value);
    }
}