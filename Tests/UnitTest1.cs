using BookStoreApp;
using BookStoreApp.src.Chirp.CSVDB;


public class UnitTests1
{
    [Theory]
    [InlineData("John","Hello")]
    public void PrintCheeps_PrintsCorrectly(string author, string message)
    {
        // Arrange
        var cheeps = new List<Cheeps>
        {
            new Cheeps { Author = author, Message = message, Timestamp = DateTime.Now },
        };

        // Act
        using (var consoleOutput = new ConsoleOutput())
        {
            UserInterface.PrintCheeps(cheeps);

            // Assert
            var output = consoleOutput.GetOutput();
            Assert.Contains($"{author}, {message},", output);
        }
    }

    
    public class ConsoleOutput : IDisposable
    {
        private readonly System.IO.StringWriter stringWriter;
        private readonly System.IO.TextWriter originalOutput;

        public ConsoleOutput()
        {
            stringWriter = new System.IO.StringWriter();
            originalOutput = Console.Out;
            Console.SetOut(stringWriter);
        }

        public string GetOutput()
        {
            return stringWriter.ToString();
        }

        public void Dispose()
        {
            Console.SetOut(originalOutput);
            stringWriter.Dispose();
        }
    }
}