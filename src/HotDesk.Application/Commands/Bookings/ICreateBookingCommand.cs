using HotDesk.Application.Dtos.Bookings;
using HotDesk.Domain.Entities;

namespace HotDesk.Application.Commands.Bookings
{
    public interface ICreateBookingCommand : ICommand<CreateBookingDto, Booking>
    {
    }
}
