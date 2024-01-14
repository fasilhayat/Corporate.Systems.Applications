using Corporate.Systems.Applications.Application5.Configuration;
using Corporate.Systems.Applications.Application5.Redis.Adapter;
using Corporate.Systems.Applications.Common;
using GraphQL.AspNet.Configuration;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var config = builder.Configuration;

RedisConnection redisConnection = new();
config.GetSection("RedisConnection").Bind(redisConnection);

//services.AddSingleton<IConnectionMultiplexer>(option =>
//    ConnectionMultiplexer.Connect(new ConfigurationOptions
//    {
//        EndPoints = { $"{redisConnection.Host}:{redisConnection.Port}" },
//        AbortOnConnectFail = false,
//        Ssl = redisConnection.IsSsl,
//        Password = redisConnection.Password
//    }));

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "cache:6380";//builder.Configuration.GetConnectionString("RedisConn");
    options.InstanceName = "App5-redis.";
});

var cachePolicy = new DistributedCacheEntryOptions
{
    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5000),
};


var redisOpstions = new RedisCacheOptions
{
    Configuration = "cache:6379",
    InstanceName = "App5-redis."
};


IDistributedCache dbClient = new RedisCache(redisOpstions);
var dbContext = new DbContext(dbClient, cachePolicy);

dbContext.SaveData(new DataKey("TestKey01"), "Her kommer lidt data");

// Add graphql services to the DI container
builder.Services.AddGraphQL();

var app = builder.Build();

// Configure the HTTP request pipeline
app.UseGraphQL();
app.Run();