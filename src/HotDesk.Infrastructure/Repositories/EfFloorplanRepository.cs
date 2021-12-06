using HotDesk.Domain.Entities;
using HotDesk.Domain.Repositories;

namespace HotDesk.Infrastructure.Repositories
{
    public class EfFloorplanRepository : EfRepository<Floorplan>, IFloorplanRepository, IDataSeedingRepository<Floorplan>
    {
        public EfFloorplanRepository(HotDeskDbContext dbContext) : base(dbContext)
        {
        }
    }
}
