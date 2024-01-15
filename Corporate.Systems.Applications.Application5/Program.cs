using Corporate.Systems.Applications.Application5.Redis.Adapter;
using GraphQL.AspNet.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add redis
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetValue<string>("Redis:Connection");
});
builder.Services.AddTransient<IDbContext, DbContext>();

// Add graphql services to the DI container
builder.Services.AddGraphQL();

var app = builder.Build();

// Configure the HTTP request pipeline
app.UseGraphQL();
app.Run();