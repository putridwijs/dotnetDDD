using ErrorOr;

using MediatR;

namespace billing_system_core.Application.ProductCategories.Command.Delete;

public record DeleteProductCategoryCommand(
    Guid Id) : IRequest<ErrorOr<bool>>;