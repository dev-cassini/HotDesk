using FluentAssertions;
using FluentValidation.TestHelper;
using HotDesk.Domain.Validators;
using HotDesk.Domain.Validators.Persons;
using HotDesk.TestHelper.Builders;
using NUnit.Framework;
using System.Threading.Tasks;

namespace HotDesk.Domain.UnitTests.Validators.Persons
{
    [TestFixture]
    public class PersonValidatorTests
    {
        [Test]
        public async Task ValidationFailsWhenFirstNameIsEmptyString()
        {
            var sut = new PersonValidator();
            var person = new PersonBuilder()
                .WithFirstName(string.Empty)
                .Build();

            var validationResult = await sut.TestValidateAsync(person);

            validationResult.IsValid.Should().BeFalse();
            validationResult.ShouldHaveValidationErrorFor(p => p.FirstName);
        }

        [Test]
        public async Task ValidationFailsWhenFirstNameExceedsMaxLength()
        {
            var sut = new PersonValidator();
            var person = new PersonBuilder()
                .WithFirstName(new string('c', ValidatorConstants.NameMaxLength + 1))
                .Build();

            var validationResult = await sut.TestValidateAsync(person);

            validationResult.IsValid.Should().BeFalse();
            validationResult.ShouldHaveValidationErrorFor(p => p.FirstName);
        }

        [Test]
        public async Task ValidationFailsWhenLastNameIsEmptyString()
        {
            var sut = new PersonValidator();
            var person = new PersonBuilder()
                .WithLastName(string.Empty)
                .Build();

            var validationResult = await sut.TestValidateAsync(person);

            validationResult.IsValid.Should().BeFalse();
            validationResult.ShouldHaveValidationErrorFor(p => p.LastName);
        }

        [Test]
        public async Task ValidationFailsWhenLastNameExceedsMaxLength()
        {
            var sut = new PersonValidator();
            var person = new PersonBuilder()
                .WithLastName(new string('c', ValidatorConstants.NameMaxLength + 1))
                .Build();

            var validationResult = await sut.TestValidateAsync(person);

            validationResult.IsValid.Should().BeFalse();
            validationResult.ShouldHaveValidationErrorFor(p => p.LastName);
        }

        [Test]
        public async Task ValidationSucceedsWhenPersonIsValid()
        {
            var sut = new PersonValidator();
            var person = new PersonBuilder().Build();

            var validationResult = await sut.TestValidateAsync(person);

            validationResult.IsValid.Should().BeTrue();
        }
    }
}
