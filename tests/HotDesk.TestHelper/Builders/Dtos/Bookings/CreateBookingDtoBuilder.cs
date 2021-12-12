using HotDesk.Application.Dtos.Bookings;

namespace HotDesk.TestHelper.Builders.Dtos.Bookings
{
    public class CreateBookingDtoBuilder
    {
        private Guid _deskId = Guid.NewGuid();
        private Guid _personId = Guid.NewGuid();
        private DateTimeOffset _startTime = DateTimeOffset.UtcNow;
        private DateTimeOffset _endTime = DateTimeOffset.UtcNow.AddDays(1);

        public CreateBookingDto Build()
        {
            return new CreateBookingDto
            {
                DeskId = _deskId,
                PersonId = _personId,
                StartTime = _startTime,
                EndTime = _endTime
            };
        }
    }
}
