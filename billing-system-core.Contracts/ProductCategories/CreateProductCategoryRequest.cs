namespace billing_system_core.Contracts.ProductCategories;

public record CreateProductCategoryRequest(
    string Name, 
    string Type, 
    string ParentCategory, 
    string Companies, 
    bool OneItemPerOrder, 
    bool OneItemPerCustomer, 
    bool AllowAssetManagement, 
    string CreatedBy, 
    string UpdatedBy, 
    string DeletedBy);