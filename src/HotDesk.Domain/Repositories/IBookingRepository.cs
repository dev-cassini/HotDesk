using HotDesk.Domain.Entities;
using System.Threading.Tasks;

namespace HotDesk.Domain.Repositories
{
    public interface IBookingRepository
    {
        Task CreateAsync(Booking booking);
    }
}
