using FluentValidation;

namespace HotDesk.Domain.Entities.Validators
{
    public class DeskValidator : AbstractValidator<Desk>
    {
        public DeskValidator()
        {
            RuleFor(desk => desk).SetValidator(new DomainEntityValidator());
            RuleFor(desk => desk.Name).NotEmpty().MaximumLength(ValidatorConstants.NameMaxLength);
        }
    }
}
