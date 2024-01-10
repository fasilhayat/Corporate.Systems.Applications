﻿using Corporate.Systems.Applications.Application4.Config;

namespace Corporate.Application.Services.Config;

public class UserServiceConfig
{
    public string? BaseAddress { get; init; }

    public ApikeyConfig? ApiKeyConfig { get; init; }
}

