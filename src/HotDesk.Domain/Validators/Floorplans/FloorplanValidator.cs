using FluentValidation;
using HotDesk.Domain.Entities;

namespace HotDesk.Domain.Validators.Floorplans
{
    public class FloorplanValidator : AbstractValidator<Floorplan>
    {
        public FloorplanValidator()
        {
            RuleFor(desk => desk).SetValidator(new DomainEntityValidator());
            RuleFor(desk => desk.Name).NotEmpty().MaximumLength(ValidatorConstants.NameMaxLength);
        }
    }
}
