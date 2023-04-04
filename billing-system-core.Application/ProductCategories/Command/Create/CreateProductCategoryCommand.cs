using billing_system_core.Domain.ProductCategoryAggregate;

using ErrorOr;

using MediatR;

namespace billing_system_core.Application.ProductCategories.Command.Create;

public record CreateProductCategoryCommand(
        string Name, 
        string Type, 
        string ParentCategory, 
        string Companies, 
        bool OneItemPerOrder, 
        bool OneItemPerCustomer, 
        bool AllowAssetManagement, 
        string CreatedBy, 
        string UpdatedBy, 
        string DeletedBy): IRequest<ErrorOr<ProductCategory>>;