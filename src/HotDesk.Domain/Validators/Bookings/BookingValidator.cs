using FluentValidation;
using HotDesk.Domain.Entities;

namespace HotDesk.Domain.Validators.Bookings
{
    public class BookingValidator : AbstractValidator<Booking>
    {
        public BookingValidator()
        {
            RuleFor(booking => booking.DeskId).NotEmpty();
            RuleFor(booking => booking.PersonId).NotEmpty();
            RuleFor(booking => booking.StartTime).NotEmpty();
            RuleFor(booking => booking.EndTime).NotEmpty().GreaterThan(booking => booking.StartTime);
        }
    }
}
