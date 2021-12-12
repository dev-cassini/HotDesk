using FluentAssertions;
using FluentValidation.TestHelper;
using HotDesk.Domain.Entities;
using HotDesk.Domain.Repositories;
using HotDesk.Domain.Validators.Bookings;
using HotDesk.TestHelper.Builders;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotDesk.Domain.UnitTest.Validators.Bookings
{
    [TestFixture]
    public class BookingForeignKeyValidatorTests
    {
        private BookingForeignKeyValidator _sut = null!;
        private Mock<IReadOnlyRepository> _readOnlyRepository = null!;

        [SetUp]
        public void SetUp()
        {
            _readOnlyRepository = new Mock<IReadOnlyRepository>();
            _sut = new BookingForeignKeyValidator(_readOnlyRepository.Object);
        }

        [Test]
        public async Task ValidationFailsWhenDeskDoesNotExist()
        {
            var person = new PersonBuilder().Build();
            var booking = new BookingBuilder().WithPersonId(person.Id).Build();

            SetupGetDesk(null);
            SetupGetPerson(person);

            var validationResult = await _sut.TestValidateAsync(booking);

            validationResult.IsValid.Should().BeFalse();
            validationResult.ShouldHaveValidationErrorFor(b => b.DeskId);
            validationResult.Errors.WithErrorMessage($"Desk {booking.DeskId} does not exist.");
        }

        [Test]
        public async Task ValidationFailsWhenPersonDoesNotExist()
        {
            var desk = new DeskBuilder().Build();
            var booking = new BookingBuilder().WithDeskId(desk.Id).Build();

            SetupGetDesk(desk);
            SetupGetPerson(null);

            var validationResult = await _sut.TestValidateAsync(booking);

            validationResult.IsValid.Should().BeFalse();
            validationResult.ShouldHaveValidationErrorFor(b => b.PersonId);
            validationResult.Errors.WithErrorMessage($"Person {booking.PersonId} does not exist.");
        }

        [Test]
        public async Task ValidationSucceedsWhenBookingForeignKeysAreValid()
        {
            var desk = new DeskBuilder().Build();
            var person = new PersonBuilder().Build();
            var booking = new BookingBuilder()
                .WithDeskId(desk.Id)
                .WithPersonId(person.Id)
                .Build();

            SetupGetDesk(desk);
            SetupGetPerson(person);

            var validationResult = await _sut.TestValidateAsync(booking);

            validationResult.IsValid.Should().BeTrue();
        }

        private void SetupGetDesk(Desk? desk)
        {
            var desks = new List<Desk>();
            if (desk is not null)
            {
                desks.Add(desk);
            }

            _readOnlyRepository.Setup(x => x.Query<Desk>()).Returns(new EnumerableQuery<Desk>(desks));
        }

        private void SetupGetPerson(Person? person)
        {
            var persons = new List<Person>();
            if (person is not null)
            {
                persons.Add(person);
            }

            _readOnlyRepository.Setup(x => x.Query<Person>()).Returns(new EnumerableQuery<Person>(persons));
        }
    }
}
