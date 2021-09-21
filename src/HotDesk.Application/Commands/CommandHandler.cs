using FluentValidation;
using HotDesk.Application.Dtos;
using HotDesk.Domain.Entities.Common;
using System.Threading.Tasks;

namespace HotDesk.Application.Commands
{
    public class CommandHandler<TDto, TDomainEntity>
        where TDto : IDto
        where TDomainEntity : IDomainEntity
    {
        private readonly ICommand<TDto, TDomainEntity> _command;

        public CommandHandler(ICommand<TDto, TDomainEntity> command)
        {
            _command = command;
        }

        public async Task HandleAsync(TDto dto)
        {
            var domainEntity = _command.Map(dto);

            foreach (var validator in _command.Validators)
            {
                await validator.ValidateAndThrowAsync(domainEntity);
            }

            await _command.ExecuteAsync(domainEntity);
        }
    }
}
