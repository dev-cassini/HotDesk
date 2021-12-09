using FluentAssertions;
using FluentValidation.TestHelper;
using HotDesk.Domain.Validators;
using HotDesk.Domain.Validators.Desks;
using HotDesk.TestHelper.Builders;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace HotDesk.Domain.UnitTests.Validators.Desks
{
    [TestFixture]
    public class DeskValidatorTests
    {
        [Test]
        public async Task ValidationFailsWhenNameIsEmptyString()
        {
            var sut = new DeskValidator();
            var desk = new DeskBuilder()
                .WithName(string.Empty)
                .Build();

            var validationResult = await sut.TestValidateAsync(desk);

            validationResult.IsValid.Should().BeFalse();
            validationResult.ShouldHaveValidationErrorFor(d => d.Name);
        }

        [Test]
        public async Task ValidationFailsWhenNameExceedsMaxLength()
        {
            var sut = new DeskValidator();
            var desk = new DeskBuilder()
                .WithName(new string('c', ValidatorConstants.NameMaxLength + 1))
                .Build();

            var validationResult = await sut.TestValidateAsync(desk);

            validationResult.IsValid.Should().BeFalse();
            validationResult.ShouldHaveValidationErrorFor(d => d.Name);
        }

        [Test]
        public async Task ValidationFailsWhenFloorplanIdIsEmptyGuid()
        {
            var sut = new DeskValidator();
            var desk = new DeskBuilder().WithFloorplanId(Guid.Empty).Build();

            var validationResult = await sut.TestValidateAsync(desk);

            validationResult.IsValid.Should().BeFalse();
            validationResult.ShouldHaveValidationErrorFor(d => d.FloorplanId);
        }

        [Test]
        public async Task ValidationFailsWhenDepartmentIdIsEmptyGuid()
        {
            var sut = new DeskValidator();
            var desk = new DeskBuilder().WithDepartmentId(Guid.Empty).Build();

            var validationResult = await sut.TestValidateAsync(desk);

            validationResult.IsValid.Should().BeFalse();
            validationResult.ShouldHaveValidationErrorFor(d => d.DepartmentId);
        }

        [Test]
        public async Task ValidationFailsWhenWidthIsLessThanMinimum()
        {
            var sut = new DeskValidator();
            var desk = new DeskBuilder().WithWidth(ValidatorConstants.MinimumDeskWidth - 1).Build();

            var validationResult = await sut.TestValidateAsync(desk);

            validationResult.IsValid.Should().BeFalse();
            validationResult.ShouldHaveValidationErrorFor(d => d.Width);
        }

        [Test]
        public async Task ValidationFailsWhenHeightIsLessThanMinimum()
        {
            var sut = new DeskValidator();
            var desk = new DeskBuilder().WithHeight(ValidatorConstants.MinimumDeskHeight - 1).Build();

            var validationResult = await sut.TestValidateAsync(desk);

            validationResult.IsValid.Should().BeFalse();
            validationResult.ShouldHaveValidationErrorFor(d => d.Height);
        }

        [Test]
        public async Task ValidationSucceedsWhenDeskIsValid()
        {
            var sut = new DeskValidator();
            var desk = new DeskBuilder().Build();

            var validationResult = await sut.TestValidateAsync(desk);

            validationResult.IsValid.Should().BeTrue();
        }
    }
}
