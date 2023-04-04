using billing_system_core.Application.Common.Interface.Persistence;
using billing_system_core.Domain.ProductCategoryAggregate;

using ErrorOr;

using MediatR;

namespace billing_system_core.Application.ProductCategories.Query.GetAll;

public class GetAllProductCategoryQueryHandler : IRequestHandler<GetAllProductCategoryQuery,
ErrorOr<List<ProductCategory>>>
// ErrorOr<ProductCategory>>
{
    private readonly IProductCategoryRepository _productCategoryRepository;

    public GetAllProductCategoryQueryHandler(IProductCategoryRepository productCategoryRepository)
    {
        _productCategoryRepository = productCategoryRepository;
    }

    public async Task<ErrorOr<List<ProductCategory>>> Handle(GetAllProductCategoryQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var result = _productCategoryRepository.GetAll();

        if (result.Result is null)
        {
            return Error.NotFound();
        }

        return result.Result;
    }
}