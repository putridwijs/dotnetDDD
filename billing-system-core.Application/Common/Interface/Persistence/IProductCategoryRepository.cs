using billing_system_core.Domain.ProductCategoryAggregate;

using ErrorOr;

namespace billing_system_core.Application.Common.Interface.Persistence;

public interface IProductCategoryRepository
{
    Task Add(ProductCategory productCategory);
    Task<ProductCategory?> GetDetail(Guid id);
    Task<List<ProductCategory>?> GetAll();
    Task<bool> Update(ProductCategory productCategory);
    Task<bool> Delete(Guid id);
}