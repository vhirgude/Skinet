using System.Text.Json;
using Core.Entities;
using Infrastructure.Data;

namespace Infrastructure.Data;
public class DataContextSeed
{
public static async Task SeedAsync(DataContext dataContext)
{
    if(!dataContext.ProductBrands.Any())
    {
        var brandData=File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
        var brand=JsonSerializer.Deserialize<List<ProductBrand>>(brandData);
        dataContext.AddRange(brand);
    }
    if(!dataContext.ProductTypes.Any())
    {
        var typedData=File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
        var type=JsonSerializer.Deserialize<List<ProductType>>(typedData);
        dataContext.AddRange(type);
    }

    if(!dataContext.Products.Any())
    {
        var productData=File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
        var product=JsonSerializer.Deserialize<List<Product>>(productData);
        dataContext.AddRange(product);
    }

    if(dataContext.ChangeTracker.HasChanges()) await dataContext.SaveChangesAsync();
}
}
