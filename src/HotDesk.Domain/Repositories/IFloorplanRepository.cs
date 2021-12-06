using HotDesk.Domain.Entities;
using System.Threading.Tasks;

namespace HotDesk.Domain.Repositories
{
    public interface IFloorplanRepository
    {
        Task CreateAsync(Floorplan floorplan);
    }
}
