using System.Data.SqlClient;

var sqlbuilder = new SqlConnectionStringBuilder();

try
{
    //sqlbuilder.DataSource = @"ID7786\SQL2019";
    sqlbuilder.ConnectionString = @"Server=DESKTOP-MALIKHO;Database=AdventureWorks2019;User Id=malik;Password=SuperSecretPassword;MultipleActiveResultSets=true";
    //sqlbuilder.UserID = "malik";
    //sqlbuilder.Password = "XXXXXXX";
    //sqlbuilder.InitialCatalog = "AdventureWorks2019";
    
    using var connection = new SqlConnection(sqlbuilder.ConnectionString);
    Console.WriteLine("\nQuery data example:");
    Console.WriteLine("=========================================\n");
    connection.Open();
    
    //var sql = "SELECT * FROM [AdventureWorks2019].[Person].[Person] WHERE BusinessEntityID = 1704";
    var sql = "SELECT name, collation_name FROM sys.databases";
    
    using var command = new SqlCommand(sql, connection);
    using SqlDataReader reader = command.ExecuteReader();
    while (reader.Read())
    {
        Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
    }
}

catch (SqlException e)
{
    Console.WriteLine(e.ToString());
}      