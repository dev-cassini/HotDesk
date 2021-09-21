using FluentValidation;
using HotDesk.Domain.Entities.Common;

namespace HotDesk.Domain.Validators
{
    public class DomainEntityValidator : AbstractValidator<DomainEntity>
    {
        public DomainEntityValidator()
        {
            RuleFor(domainEntity => domainEntity.Id).NotEmpty();
            RuleFor(domainEntity => domainEntity.CreatedAt).NotEmpty();
            RuleFor(domainEntity => domainEntity.LastUpdatedAt).NotEmpty();
        }
    }
}
