using HotDesk.Domain.Entities;
using HotDesk.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace HotDesk.Infrastructure.Repositories
{
    public class EfLocationDepartmentRepository : EfRepository<LocationDepartment>, ILocationDepartmentRepository, IDataSeedingRepository<LocationDepartment>
    {
        public EfLocationDepartmentRepository(HotDeskDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<LocationDepartment?> GetAsync(Guid locationId, Guid departmentId)
        {
            return await DbSet.SingleOrDefaultAsync(ld => ld.LocationId == locationId && ld.DepartmentId == departmentId);
        }
    }
}
