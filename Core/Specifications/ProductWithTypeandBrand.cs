using System;
using Core.Entities;

namespace Core.Specifications;
public class ProductWithTypeandBrand : BaseSpecification<Product>
{
    public ProductWithTypeandBrand(ProductSpecParams productSpecParams)
    :base(x=> 
    (!productSpecParams.BrandId.HasValue || x.ProductBrandId==productSpecParams.BrandId) &&
    (!productSpecParams.TypeId.HasValue || x.ProductTypeId==productSpecParams.TypeId)
    )
    {
        AddInclude(x=>x.ProductBrand);
        AddInclude(x=>x.ProductType); 
        ApplyPagination(productSpecParams.PageSize,productSpecParams.PageSize*(productSpecParams.PageIndex-1));       

        if(!string.IsNullOrEmpty(productSpecParams.Sort))
        {
            switch(productSpecParams.Sort)
            {
                case "priceasc":
                    AddOrderBy(x=>x.Price);
                    break;
                case "pricedsc":
                    AddOrderBy(x=>x.Price);
                    break;
                default:
                    AddOrderBy(x=>x.Name);
                    break;
            }
        }
    }

    public ProductWithTypeandBrand(int id):base(x=>x.Id==id)
    {
        AddInclude(x=>x.ProductBrand);
        AddInclude(x=>x.ProductType);
    }
}
