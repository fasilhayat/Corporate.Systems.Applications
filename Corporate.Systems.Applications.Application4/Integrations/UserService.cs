using Corporate.Application.Services.Services.Interfaces;
using Corporate.Systems.Applications.Application4.Infrastructure;
using Corporate.Systems.Applications.Application4.Model.Membership;

namespace Corporate.Systems.Applications.Application4.Integrations;

public class UserService : IUserService
{
    private readonly IServiceFactory<UserService> _serviceFactory;
    private readonly ILogger<UserService> _logger;

    public UserService(IServiceFactory<UserService> serviceFactory, ILogger<UserService> logger)
    {
        _serviceFactory = serviceFactory;
        _logger = logger;
    }

    public IEnumerable<User>? GetUsers()
    {
        var parameters = new List<KeyValuePair<string, string>>
        {
            new("size", "2"),
            new("is_json","true")
        };

        return _serviceFactory.Execute<List<User>>(parameters).Result;
    }


    public void AddUser(User user)
    {
        // TODO: Map user to external format and json serialize the external data format.
        // TODO: Mappers instantiation code here

        //var jsonObj = JsonSerializer.SerializeToDocument(user);
        _serviceFactory.Execute(user);
    }
}