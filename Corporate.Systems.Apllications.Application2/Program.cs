// See https://aka.ms/new-console-template for more information

using Corporate.Systems.Applications.Application2.Model;
using MongoDB.Bson;
using MongoDB.Driver;

/* FROM HOME
 _dbClient = new MongoClient("mongodb://localhost:27017/");
 _database = _dbClient.GetDatabase("technical-repo");
 _collection = _database.GetCollection<BsonDocument>("cachedata");

 // INSERT EXAMPLE
    var serialized = JsonSerializer.Serialize(o);
    var document = new BsonDocument
    {
        { "CacheKey", key.Identifier },
        { "Type", o.GetType().ToString() },
        { "Created", DateTime.Now.ToString(CultureInfo.InvariantCulture) },
        { "Expiry", DateTime.Now.AddMonths(6).ToString(CultureInfo.InvariantCulture)},
        { "Data", serialized }
    };
    _collection.InsertOne(document);
*/

Console.WriteLine("Hello, MongoDB!");
const string connectionString = "mongodb://mongodb:27017/";

// Create a MongoClient object by using the connection string
var client = new MongoClient(connectionString);

//Use the MongoClient to access the server
var database = client.GetDatabase("local");
var dbList = client.ListDatabases().ToList();

Console.WriteLine("The list of databases on this server is: ");

foreach (var db in dbList)
{
    Console.WriteLine(db);
}

// Data
var data = new Pensionsdata
{
    Id = "cache-1.MY-KEY0002",
    Data = "klumpdata3"
};
var bsonDocument = data.ToBsonDocument();


//get mongodb collection
var collection = database.GetCollection<BsonDocument>("local");
//await collection.InsertOneAsync();


// db.local.insertMany([ { _id: "cache-1.MY-KEY0002", pensionsdata: { data: "klumpdata3" } }, { _id: "cache-1.MY-KEY0003", pensionsdata: { data: "klumpdata4" } }])