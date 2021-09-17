using FluentValidation;

namespace HotDesk.Domain.Entities.Validators
{
    public class DepartmentValidator : AbstractValidator<Department>
    {
        public DepartmentValidator()
        {
            RuleFor(department => department).SetValidator(new DomainEntityValidator());
            RuleFor(department => department.Name).NotEmpty().MaximumLength(ValidatorConstants.NameMaxLength);
        }
    }
}
