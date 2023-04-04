namespace billing_system_core.Contracts.Product;

public record ProductResponse(
    string Id,
    string Description,
    bool DecimalQuantity,
    bool StandardAvailability,
    string AvailableAccountTypes,
    bool AssetManagement,
    string Companies,
    string ProductCode,
    string GlCode,
    float StandardAgentCommission,
    float MasterAgentCommission,
    string ExcludedCategories,
    DateTime AvailableStartDate,
    DateTime AvailableEndDate,
    int ReservationDuration,
    int Price,
    bool ManualPricing,
    string ProductCategoryId,

    DateTime CreatedAt,
    string CreatedBy,
    DateTime UpdatedAt,
    string UpdatedBy,
    DateTime DeletedAt,
    string DeletedBy);