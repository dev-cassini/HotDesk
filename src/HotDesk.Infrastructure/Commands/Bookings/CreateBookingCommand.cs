using FluentValidation;
using HotDesk.Application.Commands.Bookings;
using HotDesk.Application.Dtos.Bookings;
using HotDesk.Application.Mappers;
using HotDesk.Domain.Entities;
using HotDesk.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotDesk.Infrastructure.Commands.Bookings
{
    public class CreateBookingCommand : ICreateBookingCommand
    {
        private readonly IEnumerable<IValidator<Booking>> _validators;
        private readonly IBookingRepository _bookingRepository;

        public CreateBookingCommand(
            IEnumerable<IValidator<Booking>> validators,
            IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
            _validators = validators;
        }

        public async Task CreateAsync(CreateBookingDto createBookingDto)
        {
            var booking = createBookingDto.ToBooking(_validators.ToList());

            await _bookingRepository.CreateAsync(booking);
        }
    }
}
