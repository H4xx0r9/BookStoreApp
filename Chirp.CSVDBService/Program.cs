using BookStoreApp.SimpleDB;
using BookStoreApp.src.Chirp.CSVDB;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var db = CSVDatabase.DBInstance("C:\\Users\\Madso\\BookStoreApp\\BookStoreApp\\sdata\\chirp_cli_db.csv");

app.MapPost("/cheep", (Cheeps cheep) => db.Store(cheep));
app.MapGet("/cheeps", () => db.Read(20));
app.MapGet("/", () => "Hello world");
app.Run();

public record Cheep(string Author, string Message, DateTime Timestamp);