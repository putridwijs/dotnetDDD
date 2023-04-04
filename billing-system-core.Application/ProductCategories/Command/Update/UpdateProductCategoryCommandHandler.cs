using billing_system_core.Application.Common.Interface.Persistence;
using billing_system_core.Domain.ProductCategoryAggregate;
using billing_system_core.Domain.ProductCategoryAggregate.ValueObjects;

using ErrorOr;

using MediatR;

namespace billing_system_core.Application.ProductCategories.Command.Update;

public class UpdateProductCategoryCommandHandler : IRequestHandler<UpdateProductCategoryCommand,
    ErrorOr<bool>>
{
    private readonly IProductCategoryRepository _productCategoryRepository;

    public UpdateProductCategoryCommandHandler(IProductCategoryRepository productCategoryRepository)
    {
        _productCategoryRepository = productCategoryRepository;
    }

    public async Task<ErrorOr<bool>> Handle(UpdateProductCategoryCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var dataUpdate = ProductCategory.Update(
            ProductCategoryId.Create(request.Id), 
            request.Name,
            request.Type,
            request.ParentCategory,
            request.Companies,
            request.OneItemPerOrder,
            request.OneItemPerCustomer,
            request.AllowAssetManagement,
            DateTime.UtcNow,
            "",
            DateTime.UtcNow,
            request.UpdatedBy,
            DateTime.UtcNow,
            "");
        
        var result = _productCategoryRepository.Update(dataUpdate);

        if (result.Result is false)
        {
            return Error.NotFound("product id not found");
        }

        return result.Result;
    }
}