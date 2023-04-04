using System.Text.Json.Serialization;

namespace billing_system_core.Contracts.ProductCategories;

public record UpdateProductCategoryRequest(
    string Name, 
    string Type, 
    string ParentCategory, 
    string Companies, 
    bool OneItemPerOrder, 
    bool OneItemPerCustomer, 
    bool AllowAssetManagement, 
    string UpdatedBy,
    
    [property: JsonIgnore]
    Guid Id);