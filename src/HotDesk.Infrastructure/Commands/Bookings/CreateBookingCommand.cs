using FluentValidation;
using HotDesk.Application.Commands.Bookings;
using HotDesk.Application.Dtos.Bookings;
using HotDesk.Domain.Entities;
using HotDesk.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotDesk.Infrastructure.Commands.Bookings
{
    public class CreateBookingCommand : ICreateBookingCommand
    {
        public IEnumerable<IValidator<Booking>> Validators { get; }

        private readonly IBookingRepository _bookingRepository;

        public CreateBookingCommand(
            IBookingRepository bookingRepository,
            IEnumerable<IValidator<Booking>> validators)
        {
            _bookingRepository = bookingRepository;
            Validators = validators;
        }

        public Booking Map(CreateBookingDto createBookingDto)
        {
            return new Booking(
                Guid.NewGuid(),
                createBookingDto.DeskId,
                createBookingDto.PersonId,
                createBookingDto.StartTime,
                createBookingDto.EndTime);
        }

        public async Task ExecuteAsync(Booking booking)
        {
            await _bookingRepository.CreateAsync(booking);
        }
    }
}
