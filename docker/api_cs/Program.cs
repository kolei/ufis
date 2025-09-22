using System.Reflection;
using api_cs;
using Dapper;
using DbUp;
using MySqlConnector;

string? connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");

Console.WriteLine("connectionString (from ENV): {0}", connectionString);

if (connectionString == null)
    connectionString = "Server=127.0.0.1; Port=3308; User ID=root; Password=toor; Database=mydb;";

EnsureDatabase.For.MySqlDatabase(connectionString);

var upgrader = DeployChanges.To
    .MySqlDatabase(connectionString)
    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
    .LogToConsole()
    .Build();

var result = upgrader.PerformUpgrade();

if (!result.Successful)
{
    throw new Exception("Не смог сделать миграцию");
}

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


app.MapGet("/genre", () =>
{
    using (MySqlConnection db = new MySqlConnection(connectionString))
    {
        return db.Query<Genre>(
            "SELECT * FROM Genre");
    }
});
app.Run();