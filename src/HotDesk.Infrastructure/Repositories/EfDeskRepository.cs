using HotDesk.Domain.Entities;
using HotDesk.Domain.Repositories;
using System.Threading.Tasks;

namespace HotDesk.Infrastructure.Repositories
{
    public class EfDeskRepository : EfRepository<Desk>, IDeskRepository, IDataSeedingRepository<Desk>
    {
        public EfDeskRepository(HotDeskDbContext dbContext) : base(dbContext)
        {
        }
    }
}
