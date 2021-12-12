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
    public class FloorplanTests
    {
        [Test]
        public void ValidationExceptionIsThrownWhenOneOrMoreValidatorsFail()
        {
            var validator = new Mock<IValidator<Floorplan>>();
            validator.Setup(x => x.Validate(It.IsAny<IValidationContext>()))
                .Throws(new ValidationException("Validation failed"));

            var exception = Assert.Throws<ValidationException>(() =>
            {
                new Floorplan(
                    Guid.NewGuid(),
                    "Test Floorplan",
                    Guid.NewGuid(),
                    true,
                    new List<IValidator<Floorplan>> { validator.Object });
            });

            exception!.Message.Should().Contain("Validation failed");
        }

        [Test]
        public void PropertiesAreSetAsExpected()
        {
            var id = Guid.NewGuid();
            const string name = "Test Floorplan";
            var locationId = Guid.NewGuid();
            var enabled = true;

            var floorplan = new Floorplan(
                id,
                name,
                locationId,
                enabled,
                new List<IValidator<Floorplan>>());

            floorplan.Id.Should().Be(id);
            floorplan.Name.Should().Be(name);
            floorplan.LocationId.Should().Be(locationId);
            floorplan.Enabled.Should().Be(enabled);
        }
    }
}
