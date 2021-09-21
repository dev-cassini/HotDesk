using HotDesk.Domain.Entities;
using System.Threading.Tasks;

namespace HotDesk.Domain.Repositories
{
    public interface ILocationRepository
    {
        Task CreateAsync(Location location);
    }
}
