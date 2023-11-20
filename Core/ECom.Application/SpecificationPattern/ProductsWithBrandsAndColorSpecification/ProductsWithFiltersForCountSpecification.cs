using ECom.Application.RequestParameters;
using ECom.Domain.Entities;

namespace ECom.Application.SpecificationPattern.ProductsWithBrandsAndColorSpecification.cs;

public class ProductsWithFiltersForCountSpecification : Specification<Product>
{
    public ProductsWithFiltersForCountSpecification(ProductSpecParams productParams) : base(x =>
         (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search)) &&
         (!productParams.BrandId.HasValue || x.BrandId == productParams.BrandId) &&
         (!productParams.ColorId.HasValue || x.ColorId == productParams.ColorId) &&
         (!productParams.SizeId.HasValue || x.SizeId == productParams.SizeId))
    {

    }
}
