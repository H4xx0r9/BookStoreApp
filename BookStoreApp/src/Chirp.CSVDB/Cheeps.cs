namespace BookStoreApp.src.Chirp.CSVDB;

public record Cheeps
{
    public string Author { get; set; } = "";
    public string Message { get; set; } = "";
    public DateTime Timestamp { get; set; }
}