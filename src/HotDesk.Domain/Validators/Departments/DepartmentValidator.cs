using FluentValidation;
using HotDesk.Domain.Entities;

namespace HotDesk.Domain.Validators.Departments
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
