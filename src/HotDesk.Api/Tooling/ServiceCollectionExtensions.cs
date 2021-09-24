using HotDesk.Api.Tooling.StartupTasks;
using HotDesk.Api.Tooling.StartupTasks.Common;
using Microsoft.Extensions.DependencyInjection;

namespace HotDesk.Api.Tooling
{
    public static class ServiceCollectionExtensions
    {
        public static void AddHotDeskApiServices(this IServiceCollection services)
        {
            AddAsyncStartupTasks(services);
        }

        private static void AddAsyncStartupTasks(this IServiceCollection services)
        {
            services.AddTransient<MigrateDatabaseStartupTask>();
            services.AddTransient<DataSeederStartupTask>();
            services.AddTransient<IAsyncStartupTask, ScopedAsyncStartupTask<MigrateDatabaseStartupTask>>();
            services.AddTransient<IAsyncStartupTask, ScopedAsyncStartupTask<DataSeederStartupTask>>();
        }
    }
}
