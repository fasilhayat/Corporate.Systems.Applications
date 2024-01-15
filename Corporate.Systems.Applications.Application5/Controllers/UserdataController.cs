using Corporate.Systems.Applications.Application5.Model;
using Corporate.Systems.Applications.Application5.Redis.Adapter;
using Corporate.Systems.Applications.Common;
using GraphQL.AspNet.Attributes;
using GraphQL.AspNet.Controllers;
using System.Text.Json;

namespace Corporate.Systems.Applications.Application5.Controllers;

public class UserdataController : GraphController
{
    private readonly IDbContext _dbContext;

    public UserdataController(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [QueryRoot("user")]
    public User? RetrieveUser(string id)
    {
        //string filepath = @"C:\Users\fasil\source\\repos\Corporate.Systems.Applications\Corporate.Systems.Applications.Application5\Data\DatatFile01.json";
        var data = "{\r\n  \"DataKey\": { \"Identifier\": \"App5-redis.301fd66f-f711\" },\r\n  \"Index\": 1,\r\n  \"Guid\": \"38ad8a28-0efa-4593-a518-92c1a0245268\",\r\n  \"IsActive\": false,\r\n  \"Balance\": \"Some money as text\",\r\n  \"Picture\": \"Picture\",\r\n  \"Age\": 35,\r\n  \"EyeColor\": \"Brown\",\r\n  \"Name\": \"Garran Fas\",\r\n  \"Gender\": \"Male\",\r\n  \"Company\": \"Company name\",\r\n  \"Email\": \"malik@fas.dk\",\r\n  \"Phone\": \"\\u002B452585454\",\r\n  \"Address\": \"Address 1\",\r\n  \"About\": \"A long story\",\r\n  \"Registered\": \"Registered\",\r\n  \"Latitude\": -77.0364,\r\n  \"Longitude\": 38.8951,\r\n  \"Tags\": [ \"TAG1\", \"TAG2\", \"TAG3\" ],\r\n  \"Friends\": [\r\n    {\r\n      \"Id\": 1,\r\n      \"Name\": \"Friendname\"\r\n    },\r\n    {\r\n      \"Id\": 2,\r\n      \"Name\": \"Friendname2\"\r\n    }\r\n  ],\r\n  \"Greeting\": \"A greeting\",\r\n  \"FavoriteFruit\": \"Kiwi\"\r\n}";//File.ReadAllText(filepath);

        IDataKey datakey = new DataKey("301fd66f-f713");
        var user = _dbContext.SaveData(datakey, data);
        
        if (user != null)
        {
            var deserializedUser = JsonSerializer.Deserialize<User>(user);
            return deserializedUser;
        }

        return new User();
    }
}
