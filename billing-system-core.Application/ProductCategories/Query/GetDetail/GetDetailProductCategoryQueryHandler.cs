using billing_system_core.Application.Common.Interface.Persistence;
using billing_system_core.Domain.ProductCategoryAggregate;

using ErrorOr;

using MediatR;

namespace billing_system_core.Application.ProductCategories.Query.GetDetail;

public class GetDetailProductCategoryQueryHandler : IRequestHandler<GetDetailProductCategoryQuery,
ErrorOr<ProductCategory>>
{
    private readonly IProductCategoryRepository _productCategoryRepository;

    public GetDetailProductCategoryQueryHandler(IProductCategoryRepository productCategoryRepository)
    {
        _productCategoryRepository = productCategoryRepository;
    }

    public async Task<ErrorOr<ProductCategory>> Handle(GetDetailProductCategoryQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var result = _productCategoryRepository.GetDetail(request.id);

        if (result.Result is null)
        {
            return Error.NotFound();
        }
        
        return result.Result;
    }
}