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
    public class LocationDepartmentTests
    {
        [Test]
        public void ValidationExceptionIsThrownWhenOneOrMoreValidatorsFail()
        {
            var validator = new Mock<IValidator<LocationDepartment>>();
            validator.Setup(x => x.Validate(It.IsAny<IValidationContext>()))
                .Throws(new ValidationException("Validation failed"));

            var exception = Assert.Throws<ValidationException>(() =>
            {
                new LocationDepartment(
                    Guid.NewGuid(),
                    Guid.NewGuid(),
                    Guid.NewGuid(),
                    true,
                    new List<IValidator<LocationDepartment>> { validator.Object });
            });

            exception!.Message.Should().Contain("Validation failed");
        }

        [Test]
        public void PropertiesAreSetAsExpected()
        {
            var id = Guid.NewGuid();
            var locationId = Guid.NewGuid();
            var departmentId = Guid.NewGuid();
            var enabled = true;

            var locationDepartment = new LocationDepartment(
                id,
                locationId,
                departmentId,
                enabled,
                new List<IValidator<LocationDepartment>>());

            locationDepartment.Id.Should().Be(id);
            locationDepartment.LocationId.Should().Be(locationId);
            locationDepartment.DepartmentId.Should().Be(departmentId);
            locationDepartment.Enabled.Should().BeTrue();
        }
    }
}
