using FluentAssertions;
using FluentValidation.TestHelper;
using HotDesk.Domain.Validators.LocationDepartments;
using HotDesk.TestHelper.Builders;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace HotDesk.Domain.UnitTests.Validators.LocationDepartments
{
    [TestFixture]
    public class LocationDepartmentValidatorTests
    {
        [Test]
        public async Task ValidationFailsWhenLocationIdIsEmptyGuid()
        {
            var sut = new LocationDepartmentValidator();
            var locationDepartment = new LocationDepartmentBuilder()
                .WithLocationId(Guid.Empty)
                .Build();

            var validationResult = await sut.TestValidateAsync(locationDepartment);

            validationResult.IsValid.Should().BeFalse();
            validationResult.ShouldHaveValidationErrorFor(ld => ld.LocationId);
        }

        [Test]
        public async Task ValidationFailsWhenDepartmentIdIsEmptyGuid()
        {
            var sut = new LocationDepartmentValidator();
            var locationDepartment = new LocationDepartmentBuilder()
                .WithDepartmentId(Guid.Empty)
                .Build();

            var validationResult = await sut.TestValidateAsync(locationDepartment);

            validationResult.IsValid.Should().BeFalse();
            validationResult.ShouldHaveValidationErrorFor(ld => ld.DepartmentId);
        }

        [Test]
        public async Task ValidationSucceedsWhenLocationDepartmentIsValid()
        {
            var sut = new LocationDepartmentValidator();
            var locationDepartment = new LocationDepartmentBuilder().Build();

            var validationResult = await sut.TestValidateAsync(locationDepartment);

            validationResult.IsValid.Should().BeTrue();
        }
    }
}
