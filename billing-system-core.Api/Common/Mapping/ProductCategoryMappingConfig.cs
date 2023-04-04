using billing_system_core.Application.ProductCategories.Command;
using billing_system_core.Application.ProductCategories.Command.Create;
using billing_system_core.Application.ProductCategories.Command.Update;
using billing_system_core.Application.ProductCategories.Query;
using billing_system_core.Application.ProductCategories.Query.GetDetail;
using billing_system_core.Contracts.ProductCategories;
using billing_system_core.Domain.ProductCategoryAggregate;

using Mapster;

namespace billing_system_core.Api.Common.Mapping;

public class ProductCategoryMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateProductCategoryRequest, CreateProductCategoryCommand>();
        config.NewConfig<ProductCategory, ProductCategoryResponse>()
            .Map(dest => dest.Id, src => src.Id.Value);
        config.NewConfig<GetDetailProductCategoryQuery, Guid>()
            .Map(dest => dest, src => src.id);
        config.NewConfig<List<ProductCategory>, List<ProductCategoryResponse>>();
        config.NewConfig<UpdateProductCategoryRequest, UpdateProductCategoryCommand>();
    }
}