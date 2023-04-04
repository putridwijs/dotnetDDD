using billing_system_core.Domain.ProductAggregate;

using ErrorOr;

using MediatR;

namespace billing_system_core.Application.Products.Command;

public record CreateProductCommand(
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

    string CreatedBy,
    string UpdatedBy,
    string DeletedBy) : IRequest<ErrorOr<Product>>;