using FluentValidation;
using HotDesk.Domain.Entities;

namespace HotDesk.Domain.Validators.Bookings
{
    public class BookingValidator : AbstractValidator<Booking>
    {
        public BookingValidator()
        {
            RuleFor(booking => booking).SetValidator(new DomainEntityValidator());
            RuleFor(booking => booking.StartTime).NotEmpty();
            RuleFor(booking => booking.EndTime).NotEmpty().GreaterThan(booking => booking.StartTime);
        }
    }
}
