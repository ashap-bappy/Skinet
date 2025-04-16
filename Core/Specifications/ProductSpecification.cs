using Core.Entities;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;

namespace Core.Specifications
{
    public class ProductSpecification : BaseSpecification<Product>
    {
        public ProductSpecification(string? brand, string? type, string? sort) : base(GetExpression(brand, type))
        {
            switch (sort)
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

        private static Expression<Func<Product, bool>> GetExpression(string? brand, string? type)
        {
            return x => (string.IsNullOrWhiteSpace(brand) || x.Brand == brand) && (string.IsNullOrWhiteSpace(type) || x.Type == type);
        }
    }
}
