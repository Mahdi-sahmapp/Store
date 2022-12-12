using Application.Contracts.Specification;
using Application.Wrappers;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Queries.GetAll
{
    public class GetProductsSpec : BaseSpecification<Product>
    {
        public GetProductsSpec(GetAllProductQuery request) : base(Expression.ExpressionSpec(request))
        {
            AddInclude(a => a.ProductBrand);
            AddInclude(a => a.ProductType);
            if (request.Typesort == TypeSort.Desc)
            {
                switch (request.Sort)
                {
                    case 1:
                        AddOrderByDesc(a => a.Title);
                        break;
                    case 2:
                        AddOrderByDesc(a => a.ProductType.Title);
                        break;
                    default:
                        AddOrderByDesc(a => a.Title);
                        break;
                }
            }
            else
            {
                switch (request.Sort)
                {
                    case 1:
                        AddOrderBy(a => a.Title);
                        break;
                    case 2:
                        AddOrderBy(a => a.ProductType.Title);
                        break;
                    default:
                        AddOrderBy(a => a.Title);
                        break;
                }
            }

            ApplyPaging(request.PageSize * (request.PageIndex - 1), request.PageSize, true);

        }
        public GetProductsSpec(int id) : base(x => x.Id == id)
        {
            AddInclude(a => a.ProductBrand);
            AddInclude(a => a.ProductType);
        }

        
    }

    public class ProductCountSpec :BaseSpecification<Product>
    {
        public ProductCountSpec(GetAllProductQuery request) : base(Expression.ExpressionSpec(request))
        {
            IsPagingEnable = false;
        }
    }

    public static class Expression
    {
        public static Expression<Func<Product, bool>> ExpressionSpec(GetAllProductQuery request)
        {
            return x =>
                   (string.IsNullOrEmpty(request.Search) || x.Title.ToLower().Contains(request.Search))
                   &&
                   (!request.BrandId.HasValue || x.ProductBrandId == request.BrandId)
                   &&
                   (!request.TypeId.HasValue || x.ProductTypeId == request.TypeId);
        }
    }
}
