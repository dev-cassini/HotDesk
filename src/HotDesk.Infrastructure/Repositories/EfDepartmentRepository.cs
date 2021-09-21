using HotDesk.Domain.Entities;
using HotDesk.Domain.Repositories;

namespace HotDesk.Infrastructure.Repositories
{
    public class EfDepartmentRepository : EfRepository<Department>, IDepartmentRepository, IDataSeedingRepository<Department>
    {
        public EfDepartmentRepository(HotDeskDbContext dbContext) : base(dbContext)
        {
        }
    }
}
