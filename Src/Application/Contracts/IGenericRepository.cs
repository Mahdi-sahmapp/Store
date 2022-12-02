using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken);
        Task<TEntity> AddAsync(TEntity Entity, CancellationToken cancellationToken);
        Task<TEntity> UpdateAsync(TEntity Entity);
        Task DeleteAsync(int id, CancellationToken cancellationToken);
        void Delete(TEntity Entity);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken);

    }
}
