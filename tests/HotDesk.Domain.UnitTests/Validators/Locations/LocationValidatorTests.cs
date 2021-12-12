using FluentAssertions;
using FluentValidation.TestHelper;
using HotDesk.Domain.Validators;
using HotDesk.Domain.Validators.Locations;
using HotDesk.TestHelper.Builders;
using NUnit.Framework;
using System.Threading.Tasks;

namespace HotDesk.Domain.UnitTest.Validators.Locations
{
    [TestFixture]
    public class LocationValidatorTests
    {
        [Test]
        public async Task ValidationFailsWhenNameIsEmptyString()
        {
            var sut = new LocationValidator();
            var location = new LocationBuilder()
                .WithName(string.Empty)
                .Build();

            var validationResult = await sut.TestValidateAsync(location);

            validationResult.IsValid.Should().BeFalse();
            validationResult.ShouldHaveValidationErrorFor(l => l.Name);
        }

        [Test]
        public async Task ValidationFailsWhenNameExceedsMaxLength()
        {
            var sut = new LocationValidator();
            var location = new LocationBuilder()
                .WithName(new string('c', ValidatorConstants.NameMaxLength + 1))
                .Build();

            var validationResult = await sut.TestValidateAsync(location);

            validationResult.IsValid.Should().BeFalse();
            validationResult.ShouldHaveValidationErrorFor(l => l.Name);
        }

        [Test]
        public async Task ValidationSucceedsWhenLocationIsValid()
        {
            var sut = new LocationValidator();
            var location = new LocationBuilder().Build();

            var validationResult = await sut.TestValidateAsync(location);

            validationResult.IsValid.Should().BeTrue();
        }
    }
}
