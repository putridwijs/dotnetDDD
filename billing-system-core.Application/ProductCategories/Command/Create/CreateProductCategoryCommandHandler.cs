using billing_system_core.Application.Common.Interface.Persistence;
using billing_system_core.Domain.ProductCategoryAggregate;

using ErrorOr;

using MediatR;

namespace billing_system_core.Application.ProductCategories.Command.Create;

public class
    CreateProductCategoryCommandHandler : IRequestHandler<CreateProductCategoryCommand,
        ErrorOr<ProductCategory>>
{

    private readonly IProductCategoryRepository _productCategoryRepository;

    public CreateProductCategoryCommandHandler(IProductCategoryRepository productCategoryRepository)
    {
        _productCategoryRepository = productCategoryRepository;
    }

    public async Task<ErrorOr<ProductCategory>> Handle(CreateProductCategoryCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var productCategory = ProductCategory.Create(
            request.Name,
            request.Type,
            request.ParentCategory,
            request.Companies,
            request.OneItemPerOrder,
            request.OneItemPerCustomer,
            request.AllowAssetManagement,
            request.CreatedBy,
            request.UpdatedBy,
            request.DeletedBy
        );
        
        await _productCategoryRepository.Add(productCategory);
        return productCategory;
    }
}