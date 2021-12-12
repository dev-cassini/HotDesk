using FluentAssertions;
using FluentValidation.TestHelper;
using HotDesk.Domain.Validators;
using HotDesk.Domain.Validators.Departments;
using HotDesk.TestHelper.Builders;
using NUnit.Framework;
using System.Threading.Tasks;

namespace HotDesk.Domain.UnitTest.Validators.Departments
{
    [TestFixture]
    public class DepartmentValidatorTests
    {
        [Test]
        public async Task ValidationFailsWhenNameisEmptyString()
        {
            var sut = new DepartmentValidator();
            var department = new DepartmentBuilder()
                .WithName(string.Empty)
                .Build();

            var validationResult = await sut.TestValidateAsync(department);

            validationResult.IsValid.Should().BeFalse();
            validationResult.ShouldHaveValidationErrorFor(d => d.Name);
        }

        [Test]
        public async Task ValidationFailsWhenNameExceedsMaxLength()
        {
            var sut = new DepartmentValidator();
            var department = new DepartmentBuilder()
                .WithName(new string('c', ValidatorConstants.NameMaxLength + 1))
                .Build();

            var validationResult = await sut.TestValidateAsync(department);

            validationResult.IsValid.Should().BeFalse();
            validationResult.ShouldHaveValidationErrorFor(d => d.Name);
        }

        [Test]
        public async Task ValidationSucceedsWhenDepartmentIsValid()
        {
            var sut = new DepartmentValidator();
            var department = new DepartmentBuilder().Build();

            var validationResult = await sut.TestValidateAsync(department);

            validationResult.IsValid.Should().BeTrue();
        }
    }
}
