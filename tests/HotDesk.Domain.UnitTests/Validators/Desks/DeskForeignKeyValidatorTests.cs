using FluentAssertions;
using FluentValidation.TestHelper;
using HotDesk.Domain.Entities;
using HotDesk.Domain.Repositories;
using HotDesk.Domain.Validators.Desks;
using HotDesk.TestHelper.Builders;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotDesk.Domain.UnitTest.Validators.Desks
{
    [TestFixture]
    public class DeskForeignKeyValidatorTests
    {
        private DeskForeignKeyValidator _sut = null!;
        private Mock<IReadOnlyRepository> _readOnlyRepository = null!;

        [SetUp]
        public void SetUp()
        {
            _readOnlyRepository = new Mock<IReadOnlyRepository>();
            _sut = new DeskForeignKeyValidator(_readOnlyRepository.Object);
        }

        [Test]
        public async Task ValidationFailsWhenFloorplanDoesNotExist()
        {
            var department = new DepartmentBuilder().Build();
            var desk = new DeskBuilder().WithDepartmentId(department.Id).Build();

            SetupGetFloorplan(null);
            SetupGetDepartment(department);

            var validationResult = await _sut.TestValidateAsync(desk);

            validationResult.IsValid.Should().BeFalse();
            validationResult.ShouldHaveValidationErrorFor(b => b.FloorplanId);
            validationResult.Errors.WithErrorMessage($"Floorplan {desk.FloorplanId} does not exist.");
        }

        [Test]
        public async Task ValidationFailsWhenDepartmentDoesNotExist()
        {
            var floorplan = new FloorplanBuilder().Build();
            var desk = new DeskBuilder().WithFloorplanId(floorplan.Id).Build();

            SetupGetFloorplan(floorplan);
            SetupGetDepartment(null);

            var validationResult = await _sut.TestValidateAsync(desk);

            validationResult.IsValid.Should().BeFalse();
            validationResult.ShouldHaveValidationErrorFor(b => b.DepartmentId);
            validationResult.Errors.WithErrorMessage($"Department {desk.DepartmentId} does not exist.");
        }

        [Test]
        public async Task ValidationSucceedsWhenDeskForeignKeysAreValid()
        {
            var floorplan = new FloorplanBuilder().Build();
            var department = new DepartmentBuilder().Build();
            var desk = new DeskBuilder()
                .WithFloorplanId(floorplan.Id)
                .WithDepartmentId(department.Id)
                .Build();

            SetupGetFloorplan(floorplan);
            SetupGetDepartment(department);

            var validationResult = await _sut.TestValidateAsync(desk);

            validationResult.IsValid.Should().BeTrue();
        }

        private void SetupGetFloorplan (Floorplan? floorplan)
        {
            var floorplans = new List<Floorplan>();
            if (floorplan is not null)
            {
                floorplans.Add(floorplan);
            }

            _readOnlyRepository.Setup(x => x.Query<Floorplan>())
                .Returns(new EnumerableQuery<Floorplan>(floorplans));
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
