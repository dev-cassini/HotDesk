using FluentValidation;
using HotDesk.Domain.Entities;
using HotDesk.Domain.Repositories;
using System.Linq;

namespace HotDesk.Domain.Validators.Bookings
{
    public class BookingForeignKeyValidator : AbstractValidator<Booking>
    {
        public BookingForeignKeyValidator(IReadOnlyRepository readOnlyRepository)
        {
            RuleFor(booking => booking.DeskId)
                .Must(deskId =>
                {
                    var desk = readOnlyRepository.Query<Desk>().SingleOrDefault(d => d.Id == deskId);
                    return desk is not null;
                })
                .WithMessage(booking => $"Desk {booking.DeskId} does not exist.");

            RuleFor(booking => booking.PersonId)
                .Must(personId =>
                {
                    var person = readOnlyRepository.Query<Person>().SingleOrDefault(p => p.Id == personId);
                    return person is not null;
                })
                .WithMessage(booking => $"Person {booking.PersonId} does not exist.");
        }
    }
}
