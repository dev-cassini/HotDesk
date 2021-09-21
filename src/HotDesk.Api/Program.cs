using System.Threading.Tasks;
using HotDesk.Api.Tooling.StartupTasks.Common;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace HotDesk.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = await CreateHostBuilder(args).Build().RunAsyncStartupTasksAsync();

            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
