using FluentAssertions;
using FluentValidation.TestHelper;
using HotDesk.Domain.Entities;
using HotDesk.Domain.Repositories;
using HotDesk.Domain.Validators.Floorplans;
using HotDesk.TestHelper.Builders;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotDesk.Domain.UnitTests.Validators.Floorplans
{
    [TestFixture]
    public class FloorplanForeignKeyValidatorTests
    {
        private FloorplanForeignKeyValidator _sut = null!;
        private Mock<IReadOnlyRepository> _readOnlyRepository = null!;

        [SetUp]
        public void SetUp()
        {
            _readOnlyRepository = new Mock<IReadOnlyRepository>();
            _sut = new FloorplanForeignKeyValidator(_readOnlyRepository.Object);
        }

        [Test]
        public async Task ValidationFailsWhenLocationDoesNotExist()
        {
            var floorplan = new FloorplanBuilder().Build();

            SetupGetLocation(null);

            var validationResult = await _sut.TestValidateAsync(floorplan);

            validationResult.IsValid.Should().BeFalse();
            validationResult.ShouldHaveValidationErrorFor(f => f.LocationId);
            validationResult.Errors.WithErrorMessage($"Location {floorplan.LocationId} does not exist.");
        }

        [Test]
        public async Task ValidationSucceedsWhenFloorplanForeignKeysAreValid()
        {
            var location = new LocationBuilder().Build();
            var floorplan = new FloorplanBuilder().WithLocationId(location.Id).Build();

            SetupGetLocation(location);

            var validationResult = await _sut.TestValidateAsync(floorplan);

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
    }
}
