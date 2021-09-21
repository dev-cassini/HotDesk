using HotDesk.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace HotDesk.Domain.Repositories
{
    public interface ILocationDepartmentRepository
    {
        Task<LocationDepartment?> GetAsync(Guid locationId, Guid departmentId);
    }
}
