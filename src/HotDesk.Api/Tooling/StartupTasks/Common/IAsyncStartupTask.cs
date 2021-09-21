using System.Threading;
using System.Threading.Tasks;

namespace HotDesk.Api.Tooling.StartupTasks.Common
{
    public interface IAsyncStartupTask
    {
        Task ExecuteAsync(CancellationToken cancellationToken = default);
    }
}
