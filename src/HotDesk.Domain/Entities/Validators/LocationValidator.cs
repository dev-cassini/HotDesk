using FluentValidation;

namespace HotDesk.Domain.Entities.Validators
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
