using FluentAssertions;
using FluentValidation;
using HotDesk.Domain.Entities;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace HotDesk.Domain.UnitTest.Entities
{
    [TestFixture]
    public class PersonTests
    {
        [Test]
        public void ValidationExceptionIsThrownWhenOneOrMoreValidatorsFail()
        {
            var validator = new Mock<IValidator<Person>>();
            validator.Setup(x => x.Validate(It.IsAny<IValidationContext>()))
                .Throws(new ValidationException("Validation failed"));

            var exception = Assert.Throws<ValidationException>(() =>
            {
                new Person(
                    Guid.NewGuid(),
                    "Test",
                    "Person",
                    true,
                    new List<IValidator<Person>> { validator.Object });
            });

            exception!.Message.Should().Contain("Validation failed");
        }

        [Test]
        public void PropertiesAreSetAsExpected()
        {
            var id = Guid.NewGuid();
            const string firstName = "Test";
            const string lastName = "Person";
            var enabled = true;

            var person = new Person(
                id,
                firstName,
                lastName,
                enabled,
                new List<IValidator<Person>>());

            person.Id.Should().Be(id);
            person.FirstName.Should().Be(firstName);
            person.LastName.Should().Be(lastName);
            person.Enabled.Should().Be(enabled);
        }
    }
}
