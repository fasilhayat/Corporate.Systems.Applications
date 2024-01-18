//using GraphQL;
//using MongoDB.Bson;
//using MongoDB.Driver;

//namespace Corporate.Systems.Applications.Application2.Resources;

//public class UserQuery
//{
//    private readonly IMongoDatabase _database;

//    public UserQuery(IMongoDatabase database)
//    {
//        _database = database;
//    }

//    [GraphQLMetadata("users")]
//    public IEnumerable<User> GetUsers()
//    {
//        var collection = _database.GetCollection<BsonDocument>("pensionsdata");
//        return collection.FindAsync(document => );
//    }
//}

