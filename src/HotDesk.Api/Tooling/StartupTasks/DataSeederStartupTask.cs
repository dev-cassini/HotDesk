using HotDesk.Api.Tooling.StartupTasks.Common;
using HotDesk.Domain.Tooling;
using System.Threading;
using System.Threading.Tasks;

namespace HotDesk.Api.Tooling.StartupTasks
{
    public class DataSeederStartupTask : IAsyncStartupTask
    {
        private readonly DataSeeder _dataSeeder;

        public DataSeederStartupTask(DataSeeder dataSeeder)
        {
            _dataSeeder = dataSeeder;
        }

        public async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            await _dataSeeder.SeedAsync(cancellationToken);
        }
    }
}
