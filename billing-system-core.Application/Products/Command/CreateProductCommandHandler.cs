using billing_system_core.Application.Common.Interface.Persistence;
using billing_system_core.Domain.ProductAggregate;
using billing_system_core.Domain.ProductCategoryAggregate.ValueObjects;

using ErrorOr;

using MediatR;

namespace billing_system_core.Application.Products.Command;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ErrorOr<Product>>
{
    private readonly IProductRepository _productRepository;

    public CreateProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<ErrorOr<Product>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var product = Product.Create(
            request.Description,
            request.DecimalQuantity,
            request.StandardAvailability,
            request.AvailableAccountTypes,
            request.AssetManagement,
            request.Companies,
            request.ProductCode,
            request.GlCode,
            request.StandardAgentCommission,
            request.MasterAgentCommission,
            request.ExcludedCategories,
            request.AvailableStartDate,
            request.AvailableEndDate,
            request.ReservationDuration,
            request.Price,
            request.ManualPricing,
            ProductCategoryId.Create(new Guid(request.ProductCategoryId)),
            request.CreatedBy,
            request.UpdatedBy,
            request.DeletedBy);
        
        _productRepository.Add(product);
        return product;
    }
}