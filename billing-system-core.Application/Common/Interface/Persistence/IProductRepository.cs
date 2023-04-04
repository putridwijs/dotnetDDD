using billing_system_core.Domain.ProductAggregate;

namespace billing_system_core.Application.Common.Interface.Persistence;

public interface IProductRepository
{
    void Add(Product product);
}