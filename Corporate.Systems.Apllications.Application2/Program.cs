// See https://aka.ms/new-console-template for more information

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

// Create collection
await database.CreateCollectionAsync("pensionsdata", new CreateCollectionOptions
{
    Capped = true,
    MaxSize = 1024,
    MaxDocuments = 10,
});

var collection = database.GetCollection<BsonDocument>("pensionsdata");

// Data
IDataKey key = new DataKey("cache-1.MY-KEY0003");
var data = new Pensionsdata
{
    Id = "cache-1.MY-KEY0003",
    Data = "klumpdata3"
};

// INSERT EXAMPLE
var serialized = JsonSerializer.Serialize(data);
var document = new BsonDocument
{
    { "Key", key.Identifier },
    { "Type", data.GetType().ToString() },
    { "Created", DateTime.Now.ToString(CultureInfo.InvariantCulture) },
    { "Expiry", DateTime.Now.AddMonths(6).ToString(CultureInfo.InvariantCulture)},
    { "Data", serialized }
};
collection.InsertOne(document);

/*
 IN MONGOSHELL
# mongosh
> show dbs
admin   40.00 KiB
config  60.00 KiB
local   80.00 KiB

> use local
switched to db local
local> show collections
pensionsdata
startup_log
local> db.pensionsdata.find();
[
  {
    _id: ObjectId("659670271d7faea45f4913a4"),
    Key: 'cache-1.MY-KEY0003',
    Type: 'Corporate.Systems.Applications.Application2.Model.Pensionsdata',
    Created: '01/04/2024 08:45:27',
    Expiry: '07/04/2024 08:45:27',
    Data: '{"Id":"cache-1.MY-KEY0003","Data":"klumpdata3"}'
  }
]
local> 
 */