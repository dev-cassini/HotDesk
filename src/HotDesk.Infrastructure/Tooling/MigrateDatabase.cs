using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace HotDesk.Infrastructure.Tooling
{
    public class MigrateDatabase
    {
        private readonly HotDeskDbContext _dbContext;

        public MigrateDatabase(HotDeskDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task MigrateAsync(CancellationToken cancellationToken)
        {
            await _dbContext.Database.MigrateAsync(cancellationToken);
        }
    }
}
