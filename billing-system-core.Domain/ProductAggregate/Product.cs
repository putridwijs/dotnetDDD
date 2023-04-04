using System.Numerics;

using billing_system_core.Domain.Common.Models;
using billing_system_core.Domain.ProductAggregate.ValueObjects;
using billing_system_core.Domain.ProductCategoryAggregate.ValueObjects;

namespace billing_system_core.Domain.ProductAggregate;

public sealed class Product: AggregateRoot<ProductId>
{
    public string Description { get; private set; }
    public bool DecimalQuantity { get; private set; }
    public bool StandardAvailability { get; private set; }
    public string AvailableAccountTypes { get; private set; }
    public bool AssetManagement { get; private set; }
    public string Companies { get; private set; }
    public string ProductCode { get; private set; }
    public string GlCode { get; private set; }
    public float StandardAgentCommission { get; private set; }
    public float MasterAgentCommission { get; private set; }
    public string ExcludedCategories { get; private set; }
    public DateTime AvailableStartDate { get; private set; }
    public DateTime AvailableEndDate { get; private set; }
    public int ReservationDuration { get; private set; }
    public BigInteger Price { get; private set; }
    public bool ManualPricing { get; private set; }
    public ProductCategoryId ProductCategoryId { get; private set; }
    
    

    public DateTime CreatedAt { get; private set; }
    public string CreatedBy { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    public string UpdatedBy { get; private set; }
    public DateTime DeletedAt { get; private set; }
    public string DeletedBy { get; private set; }


    private Product(
        ProductId id,
        string description,
        bool decimalQuantity,
        bool standardAvailability,
        string availableAccountTypes,
        bool assetManagement,
        string companies,
        string productCode,
        string glCode,
        float standardAgentCommission,
        float masterAgentCommission,
        string excludedCategories,
        DateTime availableStartDate,
        DateTime availableEndDate,
        int reservationDuration,
        BigInteger price,
        bool manualPricing,
        ProductCategoryId productCategoryId,
        DateTime createdAt,
        string createdBy,
        DateTime updatedAt,
        string updatedBy,
        DateTime deletedAt,
        string deletedBy) 
        : base(id)
    {
        Description = description;
        DecimalQuantity = decimalQuantity;
        StandardAvailability = standardAvailability;
        AvailableAccountTypes = availableAccountTypes;
        AssetManagement = assetManagement;
        Companies = companies;
        ProductCode = productCode;
        GlCode = glCode;
        StandardAgentCommission = standardAgentCommission;
        MasterAgentCommission = masterAgentCommission;
        ExcludedCategories = excludedCategories;
        AvailableStartDate = availableStartDate;
        AvailableEndDate = availableEndDate;
        ReservationDuration = reservationDuration;
        Price = price;
        ManualPricing = manualPricing;
        ProductCategoryId = productCategoryId;
        CreatedAt = createdAt;
        CreatedBy = createdBy;
        UpdatedAt = updatedAt;
        UpdatedBy = updatedBy;
        DeletedAt = deletedAt;
        DeletedBy = deletedBy;
    }

    public static Product Create(
        string description,
        bool decimalQuantity,
        bool standardAvailability,
        string availableAccountTypes,
        bool assetManagement,
        string companies,
        string productCode,
        string glCode,
        float standardAgentCommission,
        float masterAgentCommission,
        string excludedCategories,
        DateTime availableStartDate,
        DateTime availableEndDate,
        int reservationDuration,
        BigInteger price,
        bool manualPricing,
        ProductCategoryId productCategoryId,
        string createdBy,
        string updatedBy,
        string deletedBy)
    {
        return new(
            ProductId.CreateUnique(),
            description,
            decimalQuantity,
            standardAvailability,
            availableAccountTypes,
            assetManagement,
            companies,
            productCode,
            glCode,
            standardAgentCommission,
            masterAgentCommission,
            excludedCategories,
            availableStartDate,
            availableEndDate,
            reservationDuration,
            price,
            manualPricing,
            productCategoryId,
            DateTime.UtcNow,
            createdBy,
            DateTime.UtcNow, 
            updatedBy,
            DateTime.UtcNow,
            deletedBy);
    }
    
#pragma warning disable CS8618
    private Product()
    {
    }
#pragma warning restore CS8618
}