using ErrorOr;

using MediatR;

namespace billing_system_core.Application.ProductCategories.Command.Update;

public record UpdateProductCategoryCommand(
    Guid Id,
    string Name, 
    string Type, 
    string ParentCategory, 
    string Companies, 
    bool OneItemPerOrder, 
    bool OneItemPerCustomer, 
    bool AllowAssetManagement, 
    string UpdatedBy) : IRequest<ErrorOr<bool>>;