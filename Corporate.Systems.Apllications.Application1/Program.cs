// See https://aka.ms/new-console-template for more information

using Corporate.Systems.Applications.Application1.Redis.Adapter;
using Corporate.Systems.Applications.Common;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.StackExchangeRedis;

Console.WriteLine("Hello, World! This is Application1 running");

IDataKey dataKey = new DataKey("MY-KEY0002");

var redisOpstions = new RedisCacheOptions
{
    Configuration = "127.0.0.1:6379",
    InstanceName = "cache-1."
};

var cachePolicy = new DistributedCacheEntryOptions
{
    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5000),
};
IDistributedCache dbClient = new RedisCache(redisOpstions);

var dataAccess = new DataAccess(dbClient, cachePolicy);

// ADD DATA
Console.WriteLine($"Adding key:'{dataKey.Identifier}'");
var res = dataAccess.CacheData(dataKey, $"Data for key: '{dataKey.Identifier}'");
Console.WriteLine($"Key:'{res}' added");

// DELETE DATA
//Console.WriteLine($"Hit any KEY to delete data for key: '{dataKey.Identifier}'");
//Console.ReadKey();
//dataAccess.ClearCachedData(dataKey);

Console.WriteLine($"Data deleted for key: '{dataKey.Identifier}'");
//Console.ReadKey();