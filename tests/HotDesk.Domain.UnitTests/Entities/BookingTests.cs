using FluentAssertions;
using FluentValidation;
using HotDesk.Domain.Entities;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace HotDesk.Domain.UnitTests.Entities
{
    [TestFixture]
    public class BookingTests
    {
        [Test]
        public void ValidationExceptionIsThrownWhenOneOrMoreValidatorsFail()
        {
            var validator = new Mock<IValidator<Booking>>();
            validator.Setup(x => x.Validate(It.IsAny<IValidationContext>()))
                .Throws(new ValidationException("Validation failed"));

            var exception = Assert.Throws<ValidationException>(() =>
            {
                new Booking(
                    Guid.NewGuid(),
                    Guid.NewGuid(),
                    Guid.NewGuid(),
                    DateTimeOffset.UtcNow,
                    DateTimeOffset.UtcNow.AddDays(1),
                    new List<IValidator<Booking>> {validator.Object});
            });

            exception!.Message.Should().Contain("Validation failed");
        }

        [Test]
        public void PropertiesAreSetAsExpected()
        {
            var id = Guid.NewGuid();
            var deskId = Guid.NewGuid();
            var personId = Guid.NewGuid();
            var startTime = DateTimeOffset.UtcNow;
            var endTime = DateTimeOffset.UtcNow.AddDays(1);

            var booking = new Booking(
                id,
                deskId,
                personId,
                startTime,
                endTime,
                new List<IValidator<Booking>>());

            booking.Id.Should().Be(id);
            booking.DeskId.Should().Be(deskId);
            booking.PersonId.Should().Be(personId);
            booking.StartTime.Should().Be(startTime);
            booking.EndTime.Should().Be(endTime);
        }
    }
}
