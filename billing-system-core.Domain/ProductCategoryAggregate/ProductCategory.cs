using billing_system_core.Domain.Common.Models;
using billing_system_core.Domain.ProductCategoryAggregate.ValueObjects;

namespace billing_system_core.Domain.ProductCategoryAggregate;

public sealed class ProductCategory: Entity<ProductCategoryId>
{
    public string Name { get; set; }
    public string Type { get; set; }
    public string ParentCategory { get; set; }
    public string Companies { get; set; }
    public bool OneItemPerOrder { get; set; }
    public bool OneItemPerCustomer { get; set; }
    public bool AllowAssetManagement { get; set; }
    
    public DateTime CreatedAt { get; set; }
    public string CreatedBy { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string UpdatedBy { get; set; }
    public DateTime DeletedAt { get; set; }
    public string DeletedBy { get; set; }


    private ProductCategory(
        ProductCategoryId productCategoryId, 
        string name,
        string type,
        string parentCategory,
        string companies,
        bool oneItemPerOrder,
        bool oneItemPerCustomer,
        bool allowAssetManagement,
        DateTime createdAt,
        string createdBy,
        DateTime updatedAt,
        string updatedBy,
        DateTime deletedAt,
        string deletedBy) 
        : base(productCategoryId)
    {
        Name = name;
        Type = type;
        ParentCategory = parentCategory;
        Companies = companies;
        OneItemPerOrder = oneItemPerOrder;
        OneItemPerCustomer = oneItemPerCustomer;
        AllowAssetManagement = allowAssetManagement;
        CreatedAt = createdAt;
        CreatedBy = createdBy;
        UpdatedAt = updatedAt;
        UpdatedBy = updatedBy;
        DeletedAt = deletedAt;
        DeletedBy = deletedBy;
    }

    public static ProductCategory Create(
        string name,
        string type,
        string parentCategory,
        string companies,
        bool oneItemPerOrder,
        bool oneItemPerCustomer,
        bool allowAssetManagement,
        string createdBy,
        string updatedBy,
        string deletedBy)
    {
        return new(
            ProductCategoryId.CreateUnique(),
            name,
            type,
            parentCategory,
            companies,
            oneItemPerOrder,
            oneItemPerCustomer,
            allowAssetManagement,
            DateTime.UtcNow,
            createdBy,
            DateTime.UtcNow,
            updatedBy,
            DateTime.UtcNow,
            deletedBy);
    }

    public static ProductCategory Update(
        ProductCategoryId productCategoryId, 
        string name,
        string type,
        string parentCategory,
        string companies,
        bool oneItemPerOrder,
        bool oneItemPerCustomer,
        bool allowAssetManagement,
        DateTime createdAt,
        string createdBy,
        DateTime updatedAt,
        string updatedBy,
        DateTime deletedAt,
        string deletedBy)
    {
        return new(
            productCategoryId,
            name,
            type,
            parentCategory,
            companies,
            oneItemPerOrder,
            oneItemPerCustomer,
            allowAssetManagement,
            createdAt,
            createdBy,
            DateTime.UtcNow,
            updatedBy,
            updatedAt,
            deletedBy);
    }
    
#pragma warning disable CS8618
    private ProductCategory()
    {
    }
#pragma warning restore CS8618
}