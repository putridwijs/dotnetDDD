using billing_system_core.Domain.ProductCategoryAggregate;

using ErrorOr;

using MediatR;

namespace billing_system_core.Application.ProductCategories.Query.GetAll;

public record GetAllProductCategoryQuery(
        // string id
        ) 
    : IRequest<ErrorOr<List<ProductCategory>>>;