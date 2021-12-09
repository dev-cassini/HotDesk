using FluentValidation;
using HotDesk.Domain.Entities;

namespace HotDesk.Domain.Validators.Floorplans
{
    public class FloorplanValidator : AbstractValidator<Floorplan>
    {
        public FloorplanValidator()
        {
            RuleFor(floorplan => floorplan).SetValidator(new DomainEntityValidator());
            RuleFor(floorplan => floorplan.Name).NotEmpty().MaximumLength(ValidatorConstants.NameMaxLength);
            RuleFor(floorplan => floorplan.LocationId).NotEmpty();
        }
    }
}
