using FluentAssertions;
using FluentValidation;
using HotDesk.Domain.Entities;
using HotDesk.Domain.Repositories;
using HotDesk.Infrastructure.Commands.Bookings;
using HotDesk.TestHelper.Builders.Dtos.Bookings;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotDesk.Infrastructure.UnitTest.Commands.Bookings
{
    [TestFixture]
    public class CreateBookingCommandTests
    {
        private CreateBookingCommand _sut = null!;
        private Mock<IValidator<Booking>> _bookingValidator = null!;
        private Mock<IBookingRepository> _bookingRepository = null!;

        [SetUp]
        public void SetUp()
        {
            _bookingValidator = new Mock<IValidator<Booking>>();
            _bookingRepository = new Mock<IBookingRepository>();

            _sut = new CreateBookingCommand(
                new List<IValidator<Booking>> {_bookingValidator.Object},
                _bookingRepository.Object);
        }

        [Test]
        public void ValidationErrorIsThrownWhenValidatorFails()
        {
            _bookingValidator.Setup(x => x.Validate(It.IsAny<IValidationContext>()))
                .Throws(new ValidationException("Validation failed."));

            var createBookingDto = new CreateBookingDtoBuilder().Build();

            var exception = Assert.ThrowsAsync<ValidationException>(async () =>
            {
                await _sut.CreateAsync(createBookingDto);
            });

            exception!.Message.Should().Contain("Validation failed.");
        }

        [Test]
        public async Task DtoIsMappedCorrectly()
        {
            var createBookingDto = new CreateBookingDtoBuilder().Build();

            await _sut.CreateAsync(createBookingDto);

            _bookingRepository.Verify(x => x.CreateAsync(It.Is<Booking>(booking =>
                booking.Id != default &&
                booking.DeskId == createBookingDto.DeskId &&
                booking.PersonId == createBookingDto.PersonId &&
                booking.StartTime == createBookingDto.StartTime &&
                booking.EndTime == createBookingDto.EndTime)));
        }

        [Test]
        public async Task BookingRepositoryIsCalledOnceToCreateBooking()
        {
            var createBookingDto = new CreateBookingDtoBuilder().Build();

            await _sut.CreateAsync(createBookingDto);

            _bookingRepository.Verify(x => x.CreateAsync(It.IsAny<Booking>()), Times.Once);
        }
    }
}
