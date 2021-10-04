using System.Collections.Generic;

namespace HotDesk.Api.Tooling.Configuration
{
    public class CorsConfiguration
    {
        public List<string> AllowedOrigins { get; init; } = new();
    }
}
