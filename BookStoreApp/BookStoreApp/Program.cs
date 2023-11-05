// See https://aka.ms/new-console-template for more information
using BookStoreApp;
using BookStoreApp.SimpleDB;
using DocoptNet;

const string usage = @"Chirp CLI version.

Usage:
  chirp read <limit>
  chirp cheep <message>
  chirp (-h | --help)
  chirp --version

Options:
  -h --help     Show this screen.
  --version     Show version.
";

var arguments = new Docopt().Apply(usage, args, version: "1.0", exit: true)!;

var action = args[0];
const string path = @"C:\Users\Madso\RiderProjects\BookStoreApp\BookStoreApp\chirp_cli_db.csv";
var database = new CSVDatabase(path);


switch (action)
{
    case "read":
    {
        int limit = int.Parse(args[1]);
        
        var pathtoData = new CSVDatabase(path);
        IEnumerable<Cheeps> cheeps = pathtoData.Read(limit);
        UserInterface.PrintCheeps(cheeps);
        
        break;
    }
    case "cheep":
    {
        var message = args[1];
        var cheep = new Cheeps() { Author = Environment.UserName, Message = message, Timestamp = DateTime.Now };
        database.Store(cheep);
        
        break;
    }
    default:
        Console.WriteLine("IMPOSSIBLE command");
        break;
}

