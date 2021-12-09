using FluentValidation;
using HotDesk.Domain.Entities;
using HotDesk.Domain.Repositories;
using System.Linq;

namespace HotDesk.Domain.Validators.LocationDepartments
{
    public class LocationDepartmentForeignKeyValidator : AbstractValidator<LocationDepartment>
    {
        public LocationDepartmentForeignKeyValidator(IReadOnlyRepository readOnlyRepository)
        {
            RuleFor(locationDepartment => locationDepartment.LocationId)
                .Must(locationId =>
                {
                    var location = readOnlyRepository.Query<Location>()
                        .SingleOrDefault(l => l.Id == locationId);

                    return location is not null;
                })
                .WithMessage(locationDepartment => $"Location {locationDepartment.LocationId} does not exist.");

            RuleFor(locationDepartment => locationDepartment.DepartmentId)
                .Must(departmentId =>
                {
                    var department = readOnlyRepository.Query<Department>()
                        .SingleOrDefault(d => d.Id == departmentId);

                    return department is not null;
                })
                .WithMessage(locationDepartment => $"Department {locationDepartment.DepartmentId} does not exist.");
        }
    }
}
