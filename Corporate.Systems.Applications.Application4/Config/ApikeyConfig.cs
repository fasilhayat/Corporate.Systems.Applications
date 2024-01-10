using Corporate.Application.Services.Config.Interfaces;

namespace Corporate.Systems.Applications.Application4.Config;

public class ApikeyConfig : IApikeyConfig
{
    public string? Key { get; init; }

    public bool EnableEncryption { get; init; }
}