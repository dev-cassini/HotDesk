using FluentValidation;
using HotDesk.Domain.Entities;

namespace HotDesk.Domain.Validators.Persons
{
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(person => person).SetValidator(new DomainEntityValidator());
            RuleFor(person => person.FirstName).NotEmpty().MaximumLength(ValidatorConstants.NameMaxLength);
            RuleFor(person => person.LastName).NotEmpty().MaximumLength(ValidatorConstants.NameMaxLength);
        }
    }
}
