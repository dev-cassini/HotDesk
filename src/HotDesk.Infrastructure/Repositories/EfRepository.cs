using HotDesk.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HotDesk.Infrastructure.Repositories
{
    public class EfRepository<TEntity> where TEntity : class, IDomainEntity
    {
        private readonly HotDeskDbContext _dbContext;
        protected readonly DbSet<TEntity> DbSet;

        public EfRepository(HotDeskDbContext dbContext)
        {
            _dbContext = dbContext;
            DbSet = dbContext.Set<TEntity>();
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);

            await _dbContext.SaveChangesAsync();
        }

        public async Task PutAsync(TEntity entity)
        {
            var entityExists = await _dbContext.Set<TEntity>().AnyAsync(e => e.Id == entity.Id);
            if (entityExists)
            {
                var entityEntry = _dbContext.Set<TEntity>().Update(entity);
                entityEntry.Property(e => e.CreatedAt).IsModified = false;
                await _dbContext.SaveChangesAsync();
                return;
            }

            await CreateAsync(entity);
        }
    }
}
