using HotDesk.Application.Dtos.Bookings;
using System.Threading.Tasks;

namespace HotDesk.Application.Commands.Bookings
{
    public interface ICreateBookingCommand
    {
        Task CreateAsync(CreateBookingDto createBookingDto);
    }
}
