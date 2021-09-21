using HotDesk.Domain.Entities;
using System.Threading.Tasks;

namespace HotDesk.Domain.Repositories
{
    public interface IDeskRepository
    {
        Task CreateAsync(Desk desk);
    }
}
