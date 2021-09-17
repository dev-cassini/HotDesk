using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotDesk.Domain.Entities.Validators
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
