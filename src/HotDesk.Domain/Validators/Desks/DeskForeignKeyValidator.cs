using FluentValidation;
using HotDesk.Domain.Entities;
using HotDesk.Domain.Repositories;
using System.Linq;

namespace HotDesk.Domain.Validators.Desks
{
    public class DeskForeignKeyValidator : AbstractValidator<Desk>
    {
        public DeskForeignKeyValidator(IReadOnlyRepository readOnlyRepository)
        {
            RuleFor(desk => desk.LocationDepartmentId)
                .Must(locationDepartmentId =>
                {
                    var locationDepartment = readOnlyRepository.Query<LocationDepartment>().SingleOrDefault(ld => ld.Id == locationDepartmentId);
                    return locationDepartment is not null;
                })
                .WithMessage(desk => $"Location department {desk.LocationDepartmentId} does not exist.");
        }
    }
}
