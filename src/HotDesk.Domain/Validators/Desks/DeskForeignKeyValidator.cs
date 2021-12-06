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
            RuleFor(desk => desk.FloorplanId)
                .Must(floorplanId =>
                {
                    var floorplan = readOnlyRepository.Query<Floorplan>()
                        .SingleOrDefault(f => f.Id == floorplanId);

                    return floorplan is not null;
                })
                .WithMessage(desk => $"Floorplan {desk.FloorplanId} does not exist.");

            RuleFor(desk => desk.DepartmentId)
                .Must(departmentId =>
                {
                    var department = readOnlyRepository.Query<Department>()
                        .SingleOrDefault(ld => ld.Id == departmentId);

                    return department is not null;
                })
                .WithMessage(desk => $"Department {desk.DepartmentId} does not exist.");
        }
    }
}
