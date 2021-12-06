using HotDesk.Application.Queries.Desks;
using HotDesk.Domain.Repositories;

namespace HotDesk.Infrastructure.Queries.Desks
{
    public class DeskQuery : IDeskQuery
    {
        public DeskQuery(IReadOnlyRepository readOnlyRepository)
        {
        }
    }
}
