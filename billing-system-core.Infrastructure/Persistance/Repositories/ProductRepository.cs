using billing_system_core.Application.Common.Interface.Persistence;
using billing_system_core.Domain.ProductAggregate;

namespace billing_system_core.Infrastructure.Persistance.Repositories;

public class ProductRepository: IProductRepository
{
    private readonly BillingSystemCoreDBContext _dbContext;

    public ProductRepository(BillingSystemCoreDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(Product product)
    {
        _dbContext.Add(product);
        _dbContext.SaveChanges();
    }
}