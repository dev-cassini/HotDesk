using FluentValidation;
using HotDesk.Domain.Entities;

namespace HotDesk.Domain.Validators.Locations
{
    public class LocationValidator : AbstractValidator<Location>
    {
        public LocationValidator()
        {
            RuleFor(location => location).SetValidator(new DomainEntityValidator());
            RuleFor(location => location.Name).NotEmpty().MaximumLength(ValidatorConstants.NameMaxLength);
        }
    }
}
