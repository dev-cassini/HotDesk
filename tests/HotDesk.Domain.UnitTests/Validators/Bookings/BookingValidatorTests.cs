using FluentAssertions;
using FluentValidation.TestHelper;
using HotDesk.Domain.Validators.Bookings;
using HotDesk.TestHelper.Builders;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace HotDesk.Domain.UnitTests.Validators.Bookings
{
    [TestFixture]
    public class BookingValidatorTests
    {
        [Test]
        public async Task ValidationFailsWhenDeskIdIsEmptyGuid()
        {
            var sut = new BookingValidator();
            var booking = new BookingBuilder().WithDeskId(Guid.Empty).Build();

            var validationResult = await sut.TestValidateAsync(booking);

            validationResult.IsValid.Should().BeFalse();
            validationResult.ShouldHaveValidationErrorFor(b => b.DeskId);
        }

        [Test]
        public async Task ValidationFailsWhenPersonIdIsEmptyGuid()
        {
            var sut = new BookingValidator();
            var booking = new BookingBuilder().WithPersonId(Guid.Empty).Build();

            var validationResult = await sut.TestValidateAsync(booking);

            validationResult.IsValid.Should().BeFalse();
            validationResult.ShouldHaveValidationErrorFor(b => b.PersonId);
        }

        [Test]
        public async Task ValidationFailsWhenStartTimeIsDefault()
        {
            var sut = new BookingValidator();
            var booking = new BookingBuilder().WithStartTime(default).Build();

            var validationResult = await sut.TestValidateAsync(booking);

            validationResult.IsValid.Should().BeFalse();
            validationResult.ShouldHaveValidationErrorFor(b => b.StartTime);
        }

        [Test]
        public async Task ValidationFailsWhenEndTimeIsDefault()
        {
            var sut = new BookingValidator();
            var booking = new BookingBuilder().WithEndTime(default).Build();

            var validationResult = await sut.TestValidateAsync(booking);

            validationResult.IsValid.Should().BeFalse();
            validationResult.ShouldHaveValidationErrorFor(b => b.EndTime);
        }

        [Test]
        public async Task ValidationFailsWhenStartTimeIsGreaterThanEndTime()
        {
            var sut = new BookingValidator();
            var booking = new BookingBuilder()
                .WithStartTime(DateTimeOffset.UtcNow)
                .WithEndTime(DateTimeOffset.UtcNow.AddDays(-1))
                .Build();

            var validationResult = await sut.TestValidateAsync(booking);

            validationResult.IsValid.Should().BeFalse();
            validationResult.ShouldHaveValidationErrorFor(b => b.EndTime);
        }

        [Test]
        public async Task ValidationSucceedsWhenBookingIsValid()
        {
            var sut = new BookingValidator();
            var booking = new BookingBuilder().Build();

            var validationResult = await sut.TestValidateAsync(booking);
            
            validationResult.IsValid.Should().BeTrue();
        }
    }
}
