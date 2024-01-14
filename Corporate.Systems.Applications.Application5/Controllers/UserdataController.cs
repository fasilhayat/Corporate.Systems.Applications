using System.Text.Json;
using Corporate.Systems.Applications.Application5.Model;
using GraphQL.AspNet.Attributes;
using GraphQL.AspNet.Controllers;
using Microsoft.Extensions.Caching.Distributed;

namespace Corporate.Systems.Applications.Application5.Controllers;

public class UserdataController : GraphController
{
    private readonly IDistributedCache _distributedCache;

    public UserdataController(IDistributedCache distributedCache)
    {
        _distributedCache = distributedCache;
    }

    //[QueryRoot("users")]
    //public IEnumerable<User> RetrieveUsers()
    //{
    //    var users = _distributedCache.
    //    return new List<User>
    //    {
    //        new()
    //        {
    //            DataKey = new("94744e79-6da7"),
    //            Name = "Noble Fulton",
    //            Guid = Guid.NewGuid(),
    //            Age = 25,
    //            Gender = "Male"
    //        },
    //        new()
    //        {
    //            DataKey = new("386a9a65-6dff"),
    //            Name = "Renee Morrow",
    //            Guid = Guid.NewGuid(),
    //            Age = 36,
    //            Gender = "Male"
    //        },
    //        new()
    //        {
    //            DataKey = new("1e00db63-144c"),
    //            Name = "Juliet Lynch",
    //            Guid = Guid.NewGuid(),
    //            Age = 18,
    //            Gender = "Female"
    //        }
    //    };
    //}

    [QueryRoot("user")]
    public User? RetrieveUser(string id)
    {
        Console.WriteLine($"Getting data for id: '{id}'");
        var user = _distributedCache.GetString(id);
        Console.WriteLine($"data found for id: '{id}'");
        Console.WriteLine($"Data: {user}");
        var deserializedUser = JsonSerializer.Deserialize<User>(user);
        return deserializedUser;
    }

    //[QueryRoot("usersearch")]
    //public User? SearchUser(string name)
    //{
    //    return RetrieveUsers().SingleOrDefault(x => x.Name != null && x.Name.Contains(name));
    //}
}
