using HotDesk.Domain.Entities.Common;
using System.Linq;

namespace HotDesk.Domain.Repositories
{
    public interface IReadOnlyRepository
    {
        IQueryable<TEntity> Query<TEntity>() where TEntity : class, IDomainEntity;
    }
}
