using HotDesk.Domain.Entities;
using System.Threading.Tasks;

namespace HotDesk.Domain.Repositories
{
    public interface IDepartmentRepository
    {
        Task CreateAsync(Department department);
    }
}
