using System;
using Core.Entities;
using Core.Specifications;

namespace Core;
public class ProductWithFilterCountSpecification : BaseSpecification<Product>
{
    public ProductWithFilterCountSpecification(ProductSpecParams productSpecParams):base(x=> 
    (!productSpecParams.BrandId.HasValue || x.ProductBrandId==productSpecParams.BrandId) &&
    (!productSpecParams.TypeId.HasValue || x.ProductTypeId==productSpecParams.TypeId)
    )
    {
    }
}
