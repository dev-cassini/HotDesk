using HotDesk.Api.Tooling.StartupTasks.Common;
using HotDesk.Infrastructure.Tooling;
using System.Threading;
using System.Threading.Tasks;

namespace HotDesk.Api.Tooling.StartupTasks
{
    public class MigrateDatabaseStartupTask : IAsyncStartupTask
    {
        private readonly MigrateDatabase _migrateDatabase;

        public MigrateDatabaseStartupTask(MigrateDatabase migrateDatabase)
        {
            _migrateDatabase = migrateDatabase;
        }

        public async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            await _migrateDatabase.MigrateAsync(cancellationToken);
        }
    }
}
