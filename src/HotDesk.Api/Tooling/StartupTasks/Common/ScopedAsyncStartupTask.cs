using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HotDesk.Api.Tooling.StartupTasks.Common
{
    public class ScopedAsyncStartupTask<T> : IAsyncStartupTask where T : IAsyncStartupTask
    {
        private readonly IServiceProvider _serviceProvider;

        public ScopedAsyncStartupTask(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task ExecuteAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _serviceProvider.CreateScope();
            var task = scope.ServiceProvider.GetRequiredService<T>();
            await task.ExecuteAsync(cancellationToken);
        }
    }
}
