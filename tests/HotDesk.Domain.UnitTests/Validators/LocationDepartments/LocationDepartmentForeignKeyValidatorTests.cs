using FluentAssertions;
using FluentValidation.TestHelper;
using HotDesk.Domain.Entities;
using HotDesk.Domain.Repositories;
using HotDesk.Domain.Validators.LocationDepartments;
using HotDesk.TestHelper.Builders;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotDesk.Domain.UnitTest.Validators.LocationDepartments
{
    [TestFixture]
    public class LocationDepartmentForeignKeyValidatorTests
    {
        private LocationDepartmentForeignKeyValidator _sut = null!;
        private Mock<IReadOnlyRepository> _readOnlyRepository = null!;

        [SetUp]
        public void SetUp()
        {
            _readOnlyRepository = new Mock<IReadOnlyRepository>();
            _sut = new LocationDepartmentForeignKeyValidator(_readOnlyRepository.Object);
        }

        [Test]
        public async Task ValidationFailsWhenLocationDoesNotExist()
        {
            var department = new DepartmentBuilder().Build();
            var locationDepartment = new LocationDepartmentBuilder()
                .WithDepartmentId(department.Id)
                .Build();

            SetupGetLocation(null);
            SetupGetDepartment(department);

            var validationResult = await _sut.TestValidateAsync(locationDepartment);

            validationResult.IsValid.Should().BeFalse();
            validationResult.ShouldHaveValidationErrorFor(ld => ld.LocationId);
            validationResult.Errors.WithErrorMessage($"Location {locationDepartment.LocationId} does not exist.");
        }

        [Test]
        public async Task ValidationFailsWhenDepartmentDoesNotExist()
        {
            var location = new LocationBuilder().Build();
            var locationDepartment = new LocationDepartmentBuilder()
                .WithLocationId(location.Id)
                .Build();

            SetupGetLocation(location);
            SetupGetDepartment(null);

            var validationResult = await _sut.TestValidateAsync(locationDepartment);

            validationResult.IsValid.Should().BeFalse();
            validationResult.ShouldHaveValidationErrorFor(ld => ld.DepartmentId);
            validationResult.Errors.WithErrorMessage($"Department {locationDepartment.DepartmentId} does not exist.");
        }

        [Test]
        public async Task ValidationSucceedsWhenLocationDepartmentForeignKeysAreValid()
        {
            var location = new LocationBuilder().Build();
            var department = new DepartmentBuilder().Build();
            var locationDepartment = new LocationDepartmentBuilder()
                .WithLocationId(location.Id)
                .WithDepartmentId(department.Id)
                .Build();

            SetupGetLocation(location);
            SetupGetDepartment(department);

            var validationResult = await _sut.TestValidateAsync(locationDepartment);

            validationResult.IsValid.Should().BeTrue();
        }

        private void SetupGetLocation(Location? location)
        {
            var locations = new List<Location>();
            if (location is not null)
            {
                locations.Add(location);
            }

            _readOnlyRepository.Setup(x => x.Query<Location>())
                .Returns(new EnumerableQuery<Location>(locations));
        }

        private void SetupGetDepartment(Department? department)
        {
            var departments = new List<Department>();
            if (department is not null)
            {
                departments.Add(department);
            }

            _readOnlyRepository.Setup(x => x.Query<Department>())
                .Returns(new EnumerableQuery<Department>(departments));
        }
    }
}
