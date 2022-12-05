using Application.Contracts;
using Application.Contracts.Specification;
using Azure.Core;
using Domain.Entities.Base;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbset;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbset = _context.Set<T>();
        }

        public async Task<T> AddAsync(T Entity, CancellationToken cancellationToken)
        {
           await _dbset.AddAsync(Entity, cancellationToken);
            return await Task.FromResult(Entity);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken)
        {
            return await _dbset.AnyAsync(expression, cancellationToken);
        }

        public void Delete(T Entity)
        {
            _context.Entry(Entity).State = EntityState.Deleted;            
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            var dbSet = await GetByIdAsync(id, cancellationToken);
            dbSet.IsDelete = true;
            await UpdateAsync(dbSet);
        }

        public async Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _dbset.ToListAsync(cancellationToken);
        }

        public async Task<T> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _dbset.FindAsync(id, cancellationToken);
        }
        
        public async Task<T> UpdateAsync(T Entity)
        {
            _context.Entry(Entity).State = EntityState.Modified;
            return await Task.FromResult(Entity);
        }

        public async Task<T> GetEntityWithSpec(ISpecification<T> spec, CancellationToken cancellationToken)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<T>> ListAsyncSpec(ISpecification<T> spec, CancellationToken cancellationToken)
        {
            return await ApplySpecification(spec).ToListAsync(cancellationToken);
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_dbset.AsQueryable(), spec);
        }
    }
}
