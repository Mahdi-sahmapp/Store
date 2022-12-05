using Application.Contracts.Specification;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Queries.GetAll
{
    public class GetProductsSpec :BaseSpecification<Product>
    {
        public GetProductsSpec()
        {
            AddInclude(a => a.ProductBrand);
            AddInclude(a => a.ProductType);
        }
        public GetProductsSpec(int id) :base(x=>x.Id == id)
        {
            AddInclude(a => a.ProductBrand);
            AddInclude(a => a.ProductType);
        }
    }
}
