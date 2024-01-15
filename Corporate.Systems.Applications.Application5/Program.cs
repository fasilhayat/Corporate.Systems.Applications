using GraphQL.AspNet.Configuration;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.StackExchangeRedis;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetValue<string>("CacheSettings:RedisCache");
});
builder.Services.Add(ServiceDescriptor.Singleton<IDistributedCache, RedisCache>());


// Add graphql services to the DI container
builder.Services.AddGraphQL();

var app = builder.Build();

// Configure the HTTP request pipeline
app.UseGraphQL();
app.Run();