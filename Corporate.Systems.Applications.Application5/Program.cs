using GraphQL.AspNet.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add graphql services to the DI container
builder.Services.AddGraphQL();

var app = builder.Build();

// Configure the HTTP request pipeline
app.UseGraphQL();
app.Run();