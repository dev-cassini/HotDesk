using FluentValidation;
using HotDesk.Domain.Entities;

namespace HotDesk.Domain.Validators.LocationDepartments
{
    public class LocationDepartmentValidator : AbstractValidator<LocationDepartment>
    {
        public LocationDepartmentValidator()
        {
            RuleFor(locationDepartment => locationDepartment).SetValidator(new DomainEntityValidator());
            RuleFor(locationDepartment => locationDepartment.LocationId).NotEmpty();
            RuleFor(locationDepartment => locationDepartment.DepartmentId).NotEmpty();
        }
    }
}
