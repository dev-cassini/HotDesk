using HotDesk.Domain.Entities.Common;
using HotDesk.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HotDesk.Infrastructure
{
    public class ReadOnlyDbContext<TDbContext> : IReadOnlyRepository
        where TDbContext : DbContext
    {
        private readonly TDbContext _dbContext;

        public ReadOnlyDbContext(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<TEntity> Query<TEntity>() where TEntity : class, IDomainEntity
        {
            return _dbContext.Set<TEntity>().AsNoTracking();
        }
    }
}
