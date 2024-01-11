using System.Globalization;
using System.Text.Json;
using Corporate.Systems.Applications.Application2.Model;
using Corporate.Systems.Applications.Common;
using MongoDB.Bson;
using MongoDB.Driver;

Console.WriteLine("Hello, MongoDB!");
const string connectionString = "mongodb://mongodb:27017/";

// Create a MongoClient object by using the connection string
var dbClient = new MongoClient(connectionString);

//Use the MongoClient to access the server
var database = dbClient.GetDatabase("local");
var dbList = dbClient.ListDatabases().ToList();

Console.WriteLine("The list of databases on this server is: ");
foreach (var db in dbList)
{
    Console.WriteLine(db);
}

// Create collection if does not exist.
var collectionExists = database.ListCollectionNames().ToList().Contains("pensionsdata");
if (!collectionExists)
{
    // Create collection
    await database.CreateCollectionAsync("pensionsdata", new CreateCollectionOptions
    {
        Capped = false
    });
}
var collection = database.GetCollection<BsonDocument>("pensionsdata");

// Data
IDataKey key = new DataKey("cache-1.MY-KEY0003");
var data = new Pensionsdata
{
    Id = "cache-1.MY-KEY0003",
    Data = "klumpdata3"
};

var serialized = JsonSerializer.Serialize(data);
var document = new BsonDocument
{
    { "_id", key.Identifier },
    { "Type", data.GetType().ToString() },
    { "Created", DateTime.Now.ToString(CultureInfo.InvariantCulture) },
    { "Expiry", DateTime.Now.AddMonths(6).ToString(CultureInfo.InvariantCulture)},
    { "Data", serialized }
};

// INSERT EXAMPLE
//collection.InsertOne(document);

// UPDATE / INSERT EXAMPLE (updates if data exists)
collection.ReplaceOne(Builders<BsonDocument>.Filter.Eq("_id", key.Identifier), document,
    new ReplaceOptions
    {
        IsUpsert = true
    });

var documents = await collection.Find(_ => true).ToListAsync();
Console.WriteLine($"documents: {documents.Count}");

//// GraphQL Query example
//Schema.For(@"
//  type User {
//      name: String,
//      gender: String
//  }

//  type Query {
//      hello: String,
//      users: [User]
//  }
//  ", _ =>
//{
//    _.Types.Include<UserQuery>();
//});
//var json = schema.Execute(_ =>
//{
//    _.Query = "{ hello }";
//    _.Root = root;
//});