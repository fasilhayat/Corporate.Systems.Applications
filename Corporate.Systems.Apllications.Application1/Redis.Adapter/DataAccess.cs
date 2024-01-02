﻿namespace Corporate.Systems.Applications.Application1.Redis.Adapter;

using Common;
using Microsoft.Extensions.Caching.Distributed;
using StackExchange.Redis;
using System.Text.Json;

internal class DataAccess : IDataAccess
{
    private readonly IDistributedCache _cache;
    private readonly DistributedCacheEntryOptions _cachePolicy;

    public DataAccess(IDistributedCache cache, DistributedCacheEntryOptions cachePolicy)
    {
        _cache = cache;
        _cachePolicy = cachePolicy;
    }

    public void Delete(IDataKey key)
    {
        // Remove datakey from datastore
        //ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("127.0.0..1:6379");
        //var server = redis.GetServer("127.0.0..1:6379");
        this.ClearCachedData(key);
    }

    public T GetCachedData<T>(IDataKey dataKey) where T : class
    {
        var document = _cache.Get(dataKey.Identifier);
        var cahchedData = document != null ? JsonSerializer.Deserialize<T>(document) : null;
        return cahchedData;
    }

    public T CacheData<T>(IDataKey key, T o) where T : class
    {
        var serializedData = JsonSerializer.SerializeToUtf8Bytes(o);
        _cache.Set(key.Identifier, serializedData, _cachePolicy);
        return o;
    }

    public void ClearCachedData(IDataKey key)
    {
        _cache.Remove(key.Identifier);
    }

    public void ClearCache()
    {
        throw new NotImplementedException();
    }
}