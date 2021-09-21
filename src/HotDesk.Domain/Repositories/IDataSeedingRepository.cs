using HotDesk.Domain.Entities.Common;
using System.Threading.Tasks;

namespace HotDesk.Domain.Repositories
{
    public interface IDataSeedingRepository<TEntity> where TEntity : class, IDomainEntity
    {
        Task PutAsync(TEntity entity);
    }
}
