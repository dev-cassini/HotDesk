using FluentAssertions;
using FluentValidation.TestHelper;
using HotDesk.Domain.Validators;
using HotDesk.Domain.Validators.Floorplans;
using HotDesk.TestHelper.Builders;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace HotDesk.Domain.UnitTest.Validators.Floorplans
{
    [TestFixture]
    public class FloorplanValidatorTests
    {
        [Test]
        public async Task ValidationFailsWhenNameIsEmptyString()
        {
            var sut = new FloorplanValidator();
            var floorplan = new FloorplanBuilder()
                .WithName(string.Empty)
                .Build();

            var validationResult = await sut.TestValidateAsync(floorplan);

            validationResult.IsValid.Should().BeFalse();
            validationResult.ShouldHaveValidationErrorFor(f => f.Name);
        }

        [Test]
        public async Task ValidationFailsWhenNameExceedsMaxLength()
        {
            var sut = new FloorplanValidator();
            var floorplan = new FloorplanBuilder()
                .WithName(new string('c', ValidatorConstants.NameMaxLength + 1))
                .Build();

            var validationResult = await sut.TestValidateAsync(floorplan);

            validationResult.IsValid.Should().BeFalse();
            validationResult.ShouldHaveValidationErrorFor(f => f.Name);
        }

        [Test]
        public async Task ValidationFailsWhenLocationIdIsEmptyGuid()
        {
            var sut = new FloorplanValidator();
            var floorplan = new FloorplanBuilder().WithLocationId(Guid.Empty).Build();

            var validationResult = await sut.TestValidateAsync(floorplan);

            validationResult.IsValid.Should().BeFalse();
            validationResult.ShouldHaveValidationErrorFor(f => f.LocationId);
        }

        [Test]
        public async Task ValidationSucceedsWhenFloorplanIsValid()
        {
            var sut = new FloorplanValidator();
            var floorplan = new FloorplanBuilder().Build();

            var validationResult = await sut.TestValidateAsync(floorplan);

            validationResult.IsValid.Should().BeTrue();
        }
    }
}
