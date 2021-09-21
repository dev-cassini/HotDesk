using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace HotDesk.Api.Tooling.StartupTasks.Common
{
    public static class AsyncStartupTaskExtensions
    {
        public static async Task<IHost> RunAsyncStartupTasksAsync(this IHost host, CancellationToken cancellationToken = default)
        {
            var tasks = host.Services.GetServices<IAsyncStartupTask>();

            foreach (var task in tasks)
            {
                await task.ExecuteAsync(cancellationToken);
            }

            return host;
        }
    }
}
