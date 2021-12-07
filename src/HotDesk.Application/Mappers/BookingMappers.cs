using FluentValidation;
using HotDesk.Application.Dtos.Bookings;
using HotDesk.Domain.Entities;
using System;
using System.Collections.Generic;

namespace HotDesk.Application.Mappers
{
    public static class BookingMappers
    {
        public static Booking ToBooking(
            this CreateBookingDto createBookingDto,
            List<IValidator<Booking>> validators)
        {
            return new Booking(
                Guid.NewGuid(),
                createBookingDto.DeskId,
                createBookingDto.PersonId,
                createBookingDto.StartTime,
                createBookingDto.EndTime,
                validators);
        }
    }
}
