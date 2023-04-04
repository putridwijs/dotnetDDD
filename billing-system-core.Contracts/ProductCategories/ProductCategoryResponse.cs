namespace billing_system_core.Contracts.ProductCategories;

public record ProductCategoryResponse(
    string Id,
    string Name, 
    string Type, 
    string ParentCategory, 
    string Companies, 
    bool OneItemPerOrder, 
    bool OneItemPerCustomer, 
    bool AllowAssetManagement, 
    DateTime CreatedAt,
    string CreatedBy, 
    DateTime UpdatedAt,
    string UpdatedBy, 
    DateTime DeletedAt,
    string DeletedBy);