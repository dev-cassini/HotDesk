using HotDesk.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace HotDesk.Api.Tooling.StartupTasks
{
    public class MigrateDatabase : IAsyncStartupTask
    {
        private readonly HotDeskDbContext _dbContext;

        public MigrateDatabase(HotDeskDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            await _dbContext.Database.MigrateAsync(cancellationToken);
        }
    }
}
