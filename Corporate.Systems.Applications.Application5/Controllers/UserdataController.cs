using Corporate.Systems.Applications.Application5.Model;
using GraphQL.AspNet.Attributes;
using GraphQL.AspNet.Controllers;
using Microsoft.Extensions.Caching.Distributed;
using System.Text;
using System.Text.Json;

namespace Corporate.Systems.Applications.Application5.Controllers;

public class UserdataController : GraphController
{
    private readonly IDistributedCache _distributedCache;

    public UserdataController(IDistributedCache distributedCache)
    {
        _distributedCache = distributedCache;
    }

    [QueryRoot("user")]
    public User? RetrieveUser(string id)
    {
        /* TEST ADGANG */
        var data = "Some data";
        byte[] bytes = Encoding.ASCII.GetBytes(data);
        _distributedCache.Set("JUstAKey001", bytes);

        var data01 = "{\r\n  \"DataKey\": { \"Identifier\": \"App5-redis.301fd66f-f711\" },\r\n  \"Index\": 1,\r\n  \"Guid\": \"38ad8a28-0efa-4593-a518-92c1a0245268\",\r\n  \"IsActive\": false,\r\n  \"Balance\": \"Some money as text\",\r\n  \"Picture\": \"Picture\",\r\n  \"Age\": 35,\r\n  \"EyeColor\": \"Brown\",\r\n  \"Name\": \"Garran Fas\",\r\n  \"Gender\": \"Male\",\r\n  \"Company\": \"Company name\",\r\n  \"Email\": \"malik@fas.dk\",\r\n  \"Phone\": \"\\u002B452585454\",\r\n  \"Address\": \"Address 1\",\r\n  \"About\": \"A long story\",\r\n  \"Registered\": \"Registered\",\r\n  \"Latitude\": -77.0364,\r\n  \"Longitude\": 38.8951,\r\n  \"Tags\": [ \"TAG1\", \"TAG2\", \"TAG3\" ],\r\n  \"Friends\": [\r\n    {\r\n      \"Id\": 1,\r\n      \"Name\": \"Friendname\"\r\n    },\r\n    {\r\n      \"Id\": 2,\r\n      \"Name\": \"Friendname2\"\r\n    }\r\n  ],\r\n  \"Greeting\": \"A greeting\",\r\n  \"FavoriteFruit\": \"Kiwi\"\r\n}1";
        var databytes = Encoding.ASCII.GetBytes(data01);
        _distributedCache.Set("App5-redis.301fd66f-f711", databytes);

        Console.WriteLine($"Getting data for id: '{id}'");
        var user = _distributedCache.Get(id);
        
        Console.WriteLine($"data found for id: '{id}'");
        Console.WriteLine($"Data: {user}");

        if (user != null)
        {
            var deserializedUser = JsonSerializer.Deserialize<User>(user);
            return deserializedUser;
        }

        return new User();
    }
}
