using billing_system_core.Domain.ProductCategoryAggregate;

using ErrorOr;

using MediatR;

namespace billing_system_core.Application.ProductCategories.Query.GetDetail;

public record GetDetailProductCategoryQuery(
    Guid id) : IRequest<ErrorOr<ProductCategory>>;