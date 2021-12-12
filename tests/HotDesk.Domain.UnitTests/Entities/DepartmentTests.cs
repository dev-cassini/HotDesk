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
    public class DepartmentTests
    {
        [Test]
        public void ValidationExceptionIsThrownWhenOneOrMoreValidatorsFail()
        {
            var validator = new Mock<IValidator<Department>>();
            validator.Setup(x => x.Validate(It.IsAny<IValidationContext>()))
                .Throws(new ValidationException("Validation failed"));

            var exception = Assert.Throws<ValidationException>(() =>
            {
                new Department(
                    Guid.NewGuid(),
                    "Test Department",
                    true,
                    new List<IValidator<Department>> { validator.Object });
            });

            exception!.Message.Should().Contain("Validation failed");
        }

        [Test]
        public void PropertiesAreSetAsExpected()
        {
            var id = Guid.NewGuid();
            const string name = "Test Department";
            var enabled = true;

            var department = new Department(
                id,
                name,
                enabled,
                new List<IValidator<Department>>());

            department.Id.Should().Be(id);
            department.Name.Should().Be(name);
            department.Enabled.Should().Be(enabled);
            
        }
    }
}
