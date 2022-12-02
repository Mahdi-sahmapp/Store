using Application.Contracts;
using Domain.Entities.Base;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Persistence
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public DbContext Context => _context;

        public IGenericRepository<T> Repository<T>() where T : BaseEntity
        {           

            return new GenericRepository<T>(_context);
        }

        public Task<int> Save(CancellationToken cancellationToken)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }
    }
}
