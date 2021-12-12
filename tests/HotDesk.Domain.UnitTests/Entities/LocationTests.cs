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
    public class LocationTests
    {
        [Test]
        public void ValidationExceptionIsThrownWhenOneOrMoreValidatorsFail()
        {
            var validator = new Mock<IValidator<Location>>();
            validator.Setup(x => x.Validate(It.IsAny<IValidationContext>()))
                .Throws(new ValidationException("Validation failed"));

            var exception = Assert.Throws<ValidationException>(() =>
            {
                new Location(
                    Guid.NewGuid(),
                    "Test Location",
                    true,
                    new List<IValidator<Location>> { validator.Object });
            });

            exception!.Message.Should().Contain("Validation failed");
        }

        [Test]
        public void PropertiesAreSetAsExpected()
        {
            var id = Guid.NewGuid();
            const string name = "Test Location";
            var enabled = true;

            var location = new Location(
                id,
                name,
                enabled,
                new List<IValidator<Location>>());

            location.Id.Should().Be(id);
            location.Name.Should().Be(name);
            location.Enabled.Should().Be(enabled);
        }
    }
}
