using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotDesk.Domain.Entities.Validators
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
