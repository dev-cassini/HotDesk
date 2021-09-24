namespace HotDesk.Api.Tooling.Configuration
{
    public class IdentityServerConfiguration
    {
        public string Url { get; init; } = string.Empty;

        public string HotDeskApiAdminScope { get; init; } = string.Empty;

        public string SwaggerClientId { get; init; } = string.Empty;

        public string Audience { get; init; } = string.Empty;

        public bool ValidateAudience { get; init; }

        public bool RequiresHttps { get; init; }

        public bool RequiresAuthentication { get; init; }

        public bool RequiresAuthorisation { get; init; }
    }
}
