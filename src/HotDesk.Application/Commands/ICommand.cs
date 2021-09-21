using FluentValidation;
using HotDesk.Application.Dtos;
using HotDesk.Domain.Entities.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotDesk.Application.Commands
{
    public interface ICommand<TDto, TDomainEntity>
        where TDto : IDto
        where TDomainEntity : IDomainEntity
    {
        IEnumerable<IValidator<TDomainEntity>> Validators { get; }
        TDomainEntity Map(TDto dto);
        Task ExecuteAsync(TDomainEntity domainEntity);
    }
}
