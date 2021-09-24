using System.Reflection;

namespace HotDesk.Api.Tooling.Configuration
{
    public class ServiceInstanceConfiguration
    {
        private const string Unknown = "Unknown";

        public string ServiceName { get; init; } = Assembly.GetEntryAssembly()?.GetName().Name ?? Unknown;
        public string Version { get; init; } = Assembly.GetEntryAssembly()?.GetName().Version?.ToString() ?? Unknown;
        public string MajorVersion { get; init; } = Assembly.GetEntryAssembly()?.GetName().Version?.Major.ToString() ?? Unknown;
    }
}
