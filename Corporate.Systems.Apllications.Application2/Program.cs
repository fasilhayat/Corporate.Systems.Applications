// See https://aka.ms/new-console-template for more information

using MongoDB.Bson;
using MongoDB.Driver;

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


//get mongodb collection
var collection = database.GetCollection<BsonDocument>("local");
//await collection.InsertOneAsync();


// db.local.insertMany([ { _id: "cache-1.MY-KEY0002", pensionsdata: { data: "klumpdata3" } }, { _id: "cache-1.MY-KEY0003", pensionsdata: { data: "klumpdata4" } }])