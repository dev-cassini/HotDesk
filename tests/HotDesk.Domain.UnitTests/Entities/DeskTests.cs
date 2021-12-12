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
    public class DeskTests
    {
        [Test]
        public void ValidationExceptionIsThrownWhenOneOrMoreValidatorsFail()
        {
            var validator = new Mock<IValidator<Desk>>();
            validator.Setup(x => x.Validate(It.IsAny<IValidationContext>()))
                .Throws(new ValidationException("Validation failed"));

            var exception = Assert.Throws<ValidationException>(() =>
            {
                new Desk(
                    Guid.NewGuid(),
                    "Test Desk",
                    Guid.NewGuid(),
                    Guid.NewGuid(),
                    100,
                    100,
                    50,
                    50,
                    true,
                    new List<IValidator<Desk>> { validator.Object });
            });

            exception!.Message.Should().Contain("Validation failed");
        }

        [Test]
        public void PropertiesAreSetAsExpected()
        {
            var id = Guid.NewGuid();
            const string name = "Test Desk";
            var floorplanId = Guid.NewGuid();
            var departmentId = Guid.NewGuid();
            var xCoordinate = 100;
            var yCoordinate = 100;
            var width = 50;
            var height = 50;
            var enabled = true;

            var desk = new Desk(
                id,
                name,
                floorplanId,
                departmentId,
                xCoordinate,
                yCoordinate,
                width,
                height,
                enabled,
                new List<IValidator<Desk>>());

            desk.Id.Should().Be(id);
            desk.Name.Should().Be(name);
            desk.FloorplanId.Should().Be(floorplanId);
            desk.DepartmentId.Should().Be(departmentId);
            desk.XCoordinate.Should().Be(xCoordinate);
            desk.YCoordinate.Should().Be(yCoordinate);
            desk.Width.Should().Be(width);
            desk.Height.Should().Be(height);
            desk.Enabled.Should().Be(enabled);
        }
    }
}
