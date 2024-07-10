using System;
using Core.Entities;

namespace Core.Specifications;
public class ProductWithTypeandBrand : BaseSpecification<Product>
{
    public ProductWithTypeandBrand()
    {
        AddInclude(x=>x.ProductBrand);
        AddInclude(x=>x.ProductType);
    }

    public ProductWithTypeandBrand(int id):base(x=>x.Id==id)
    {
        AddInclude(x=>x.ProductBrand);
        AddInclude(x=>x.ProductType);
    }
}
