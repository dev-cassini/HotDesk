using HotDesk.Domain.Entities;
using HotDesk.Domain.Repositories;

namespace HotDesk.Infrastructure.Repositories
{
    public class EfPersonRepository : EfRepository<Person>, IPersonRepository, IDataSeedingRepository<Person>
    {
        public EfPersonRepository(HotDeskDbContext dbContext) : base(dbContext)
        {
        }
    }
}
