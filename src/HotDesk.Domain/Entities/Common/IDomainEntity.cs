using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotDesk.Domain.Entities.Common
{
    public interface IDomainEntity
    {
        Guid Id { get; }
    }
}
