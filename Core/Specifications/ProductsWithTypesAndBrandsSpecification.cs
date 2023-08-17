using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandsSpecification()
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }

        public ProductsWithTypesAndBrandsSpecification(int id)
            : base(x => x.Id == id) // We are calling the BaseSpecification constructor with the generic expression
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }
    }
}