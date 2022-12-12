using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Specification
{
    public class BaseSpecification<T> : ISpecification<T> where T : BaseEntity
    {
        //x=>x.t = t1
        public Expression<Func<T, bool>> Predicate { get; }

        public List<Expression<Func<T, object>>> Includs { get; } = new();

        public Expression<Func<T, object>> OrderBy { get; private set; }

        public Expression<Func<T, object>> OrderByDesc { get; private set; }

        public int Take { get; set; }

        public int Skip { get; set; }

        public bool IsPagingEnable { get; set; } = true;

        public BaseSpecification()
        {

        }

        public BaseSpecification(Expression<Func<T, bool>> preddicate)
        {
            Predicate = preddicate;
        }
        protected void AddInclude(Expression<Func<T, object>> include)
        {
            Includs.Add(include);   
        }

        protected void AddOrderBy(Expression<Func<T,object>> orederbyExpression)
        {
            OrderBy = orederbyExpression;
        }

        protected void AddOrderByDesc(Expression<Func<T, object>> orederbydecsExpression)
        {
            OrderByDesc = orederbydecsExpression;
        }

        protected void ApplyPaging(int skip,int take,bool isPagingEnable = true)
        {
            Skip = skip;
            Take = take;
            IsPagingEnable = isPagingEnable;
        }
    }
}
