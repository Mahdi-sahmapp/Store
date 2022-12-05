using Application.Features.ProductBrands.Queries.GetAll;
using Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Specification
{
    public class SpecificationEvaluator<T> where T:BaseEntity
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> Queryable)
        {
            var query = inputQuery.AsQueryable();

            if(Queryable.Predicate != null)  
                query = query.Where(Queryable.Predicate);

            if (Queryable.Includs.Any()) 
                query = Queryable.Includs.Aggregate(query, (current, value) => current.Include(value));

            return query;
        }

    }
}
