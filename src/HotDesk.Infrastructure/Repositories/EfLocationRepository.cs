using HotDesk.Domain.Entities;
using HotDesk.Domain.Repositories;

namespace HotDesk.Infrastructure.Repositories
{
    public class EfLocationRepository : EfRepository<Location>, ILocationRepository, IDataSeedingRepository<Location>
    {
        public EfLocationRepository(HotDeskDbContext dbContext) : base(dbContext)
        {
        }
    }
}
