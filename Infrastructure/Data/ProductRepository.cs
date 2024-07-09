using Core;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;
public class ProductRepository : IProductRepository
{
    private readonly DataContext _dbContext;

    public ProductRepository(DataContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyList<ProductBrand>> GetProductBrandAsync()
    {
        return await _dbContext.ProductBrands.ToListAsync();
    }

    public async Task<Product> GetProductByIdAsync(int id)
    {
        return await _dbContext.Products
        .Include(p=>p.ProductBrand)
        .Include(p=>p.ProductType)
        .FirstOrDefaultAsync(p=>p.Id==id);
    }

    public async Task<IReadOnlyList<Product>> GetProductsAsync()
    {
        return await _dbContext.Products
        .Include(p=>p.ProductBrand)
        .Include(p=>p.ProductType)
        .ToListAsync();
    }

    public async Task<IReadOnlyList<ProductType>> GetProductTypeAsync()
    {
        return await _dbContext.ProductTypes.ToListAsync();
    }
}
