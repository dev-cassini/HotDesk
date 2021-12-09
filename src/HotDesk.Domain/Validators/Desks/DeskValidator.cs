using FluentValidation;
using HotDesk.Domain.Entities;

namespace HotDesk.Domain.Validators.Desks
{
    public class DeskValidator : AbstractValidator<Desk>
    {
        public DeskValidator()
        {
            RuleFor(desk => desk).SetValidator(new DomainEntityValidator());
            RuleFor(desk => desk.Name).NotEmpty().MaximumLength(ValidatorConstants.NameMaxLength);
            RuleFor(desk => desk.FloorplanId).NotEmpty();
            RuleFor(desk => desk.DepartmentId).NotEmpty();
            RuleFor(desk => desk.Width).GreaterThanOrEqualTo(ValidatorConstants.MinimumDeskWidth);
            RuleFor(desk => desk.Height).GreaterThanOrEqualTo(ValidatorConstants.MinimumDeskHeight);
        }
    }
}
