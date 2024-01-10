using Corporate.Application.Services.Config;

namespace Corporate.Systems.Applications.Application4.Config
{
    public class CreditcardServiceConfig
    {
        public string? BaseAddress { get; init; }

        public JwtConfig? JwtConfig { get; init; }
    }
}
