namespace Corporate.Systems.Applications.Application5.Configuration
{
    public class RedisConnection
    {
        public string? Host { get; init; }

        public string? Port { get; init; }

        public bool IsSsl { get; init; }

        public string? Password { get; init; }
    }
}
