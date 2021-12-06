using HotDesk.Application.Dtos.Desks;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotDesk.Application.Queries.Desks
{
    public interface IDeskQuery
    {
        Task<List<DeskDto>> GetAsync(Guid locationId, Guid departmentId);
    }
}
