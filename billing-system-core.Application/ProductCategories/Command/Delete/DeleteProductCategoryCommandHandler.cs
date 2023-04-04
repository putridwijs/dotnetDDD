using billing_system_core.Application.Common.Interface.Persistence;

using ErrorOr;

using MediatR;

namespace billing_system_core.Application.ProductCategories.Command.Delete;

public class DeleteProductCategoryCommandHandler : IRequestHandler<DeleteProductCategoryCommand,
    ErrorOr<bool>>
{
    private readonly IProductCategoryRepository _productCategoryRepository;

    public DeleteProductCategoryCommandHandler(IProductCategoryRepository productCategoryRepository)
    {
        _productCategoryRepository = productCategoryRepository;
    }

    public async Task<ErrorOr<bool>> Handle(DeleteProductCategoryCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var result = await _productCategoryRepository.Delete(request.Id);
        if (result is false)
        {
            return Error.NotFound("Product category not found.");
        }

        return result;
    }
}