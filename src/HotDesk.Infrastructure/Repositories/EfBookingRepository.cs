using HotDesk.Domain.Entities;
using HotDesk.Domain.Repositories;
using System.Threading.Tasks;

namespace HotDesk.Infrastructure.Repositories
{
    public class EfBookingRepository : EfRepository<Booking>, IBookingRepository, IDataSeedingRepository<Booking>
    {
        public EfBookingRepository(HotDeskDbContext dbContext) : base(dbContext)
        {
        }
    }
}
