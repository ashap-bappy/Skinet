using Core.Entities;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;

namespace Core.Specifications
{
    public class ProductSpecification : BaseSpecification<Product>
    {
        public ProductSpecification(ProductSpecParams specParams) : base(GetExpression(specParams.Brands, specParams.Types, specParams.Search))
        {
            ApplyPaging(specParams.PageSize * (specParams.PageIndex - 1), specParams.PageSize, true);
            switch (specParams.Sort)
            {
                case "priceAsc":
                    AddOrderBy(p => p.Price);
                    break;
                case "priceDesc":
                    AddOrderByDescending(p => p.Price);
                    break;
                default:
                    AddOrderBy(p => p.Name);
                    break;
            }
        }

        private static Expression<Func<Product, bool>> GetExpression(List<string> brands, List<string> types,
            string search)
        {
            return x => (string.IsNullOrEmpty(search) || x.Name.ToLower().Contains(search)) &&
                        (brands.Count == 0 || brands.Contains(x.Brand)) && (types.Count == 0 || types.Contains(x.Type));
        }
    }
}
