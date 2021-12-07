using FluentValidation;
using HotDesk.Domain.Entities;

namespace HotDesk.TestHelper.Builders
{
    public class BookingBuilder
    {
        private Guid _id = Guid.NewGuid();
        private Guid _deskId = Guid.NewGuid();
        private Guid _personId = Guid.NewGuid();
        private DateTimeOffset _startTime = DateTimeOffset.UtcNow;
        private DateTimeOffset _endTime = DateTimeOffset.UtcNow.AddDays(1);

        public Booking Build()
        {
            return new Booking(
                _id,
                _deskId,
                _personId,
                _startTime,
                _endTime,
                new List<IValidator<Booking>>());
        }

        public BookingBuilder WithDeskId(Guid deskId)
        {
            _deskId = deskId;
            return this;
        }

        public BookingBuilder WithPersonId(Guid personId)
        {
            _personId = personId;
            return this;
        }

        public BookingBuilder WithStartTime(DateTimeOffset startTime)
        {
            _startTime = startTime;
            return this;
        }

        public BookingBuilder WithEndTime(DateTimeOffset endTime)
        {
            _endTime = endTime;
            return this;
        }
    }
}
