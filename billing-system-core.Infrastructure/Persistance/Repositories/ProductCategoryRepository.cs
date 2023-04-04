using billing_system_core.Application.Common.Interface.Persistence;
using billing_system_core.Domain.ProductCategoryAggregate;
using billing_system_core.Domain.ProductCategoryAggregate.ValueObjects;

using ErrorOr;

using Microsoft.EntityFrameworkCore;

namespace billing_system_core.Infrastructure.Persistance.Repositories;

public class ProductCategoryRepository: IProductCategoryRepository
{
    private readonly BillingSystemCoreDBContext _dbContext;


    public ProductCategoryRepository(BillingSystemCoreDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(ProductCategory productCategory)
    {
        _dbContext.Add(productCategory);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<ProductCategory?> GetDetail(Guid id)
    { 
        var productCategoryId = ProductCategoryId.Create(id); 
        return await _dbContext.ProductCategories
            .FirstOrDefaultAsync(x => x.Id == productCategoryId);
    }

    public async Task<List<ProductCategory>?> GetAll()
    {
        return await _dbContext.ProductCategories
            .ToListAsync();
    }

    public async Task<bool> Update(ProductCategory productCategory)
    {
        var data = await GetDetail(productCategory.Id.Value);
        if (data is null)
        {
            return false;
        }

        data.Name = productCategory.Name;
        data.Type = productCategory.Type;
        data.ParentCategory = productCategory.ParentCategory;
        data.Companies = productCategory.Companies;
        data.OneItemPerOrder = productCategory.OneItemPerOrder;
        data.OneItemPerCustomer = productCategory.OneItemPerCustomer;
        data.AllowAssetManagement = productCategory.AllowAssetManagement;
        data.UpdatedBy = productCategory.UpdatedBy;

        _dbContext.ProductCategories.Update(data);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Delete(Guid id)
    {
        var data = await GetDetail(id);
        if (data is null)
        {
            return false;
        }

        _dbContext.ProductCategories.Remove(data);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}