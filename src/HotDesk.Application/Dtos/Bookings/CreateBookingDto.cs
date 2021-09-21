using System;

namespace HotDesk.Application.Dtos.Bookings
{
    public class CreateBookingDto : IDto
    {
        public Guid DeskId { get; init; }

        public Guid PersonId { get; init; }

        public DateTimeOffset StartTime { get; init; }

        public DateTimeOffset EndTime { get; init; }
    }
}
