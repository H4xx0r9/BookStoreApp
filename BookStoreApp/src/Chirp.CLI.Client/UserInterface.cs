
using BookStoreApp.src.Chirp.CSVDB;

namespace BookStoreApp;

public static class UserInterface
{
    public static void PrintCheeps(IEnumerable<Cheeps> cheeps)
    {
        foreach (var record in cheeps)
        {
            Console.WriteLine($"{record.Author}, {record.Message}, {record.Timestamp}");
        }
        
        
    }
}