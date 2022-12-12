﻿using Application.Features.ProductBrands.Queries.GetAll;
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
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> specification)
        {
            var query = inputQuery.AsQueryable();
              
            if(specification.Predicate != null)  
                query = query.Where(specification.Predicate);

            if (specification.Includs.Any()) 
                query = specification.Includs.Aggregate(query, (current, value) => current.Include(value));

            if (specification.OrderBy != null)
                query = query.OrderBy(specification.OrderBy);

            if (specification.OrderByDesc != null)
                query = query.OrderByDescending(specification.OrderByDesc);

            if(specification.IsPagingEnable)
                query = query.Skip(specification.Skip).Take(specification.Take);    

            return query;
        }

    }
}
