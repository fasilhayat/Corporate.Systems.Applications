namespace Corporate.Systems.Applications.Application5.Redis.Adapter;

using Common;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

internal class DbContext : IDbContext
{
    private readonly IDistributedCache _cache;
    private readonly DistributedCacheEntryOptions _cachePolicy;

    public DbContext(IDistributedCache cache, DistributedCacheEntryOptions cachePolicy)
    {
        _cache = cache;
        _cachePolicy = cachePolicy;
    }

    public void Delete(IDataKey key)
    {
        // Remove datakey from datastore
        //ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("127.0.0..1:6379");
        //var server = redis.GetServer("127.0.0..1:6379");
        this.ClearData(key);
    }

    public T? GetData<T>(IDataKey dataKey) where T : class
    {
        var document = _cache.Get(dataKey.Identifier);
        var cahchedData = document != null ? JsonSerializer.Deserialize<T>(document) : null;
        return cahchedData;
    }

    public T SaveData<T>(IDataKey key, T o) where T : class
    {
        var serializedData = JsonSerializer.SerializeToUtf8Bytes(o);
        _cache.Set(key.Identifier, serializedData, _cachePolicy);
        return o;
    }

    public void ClearData(IDataKey key)
    {
        _cache.Remove(key.Identifier);
    }

    public void ClearAllData()
    {
        throw new NotImplementedException();
    }
}