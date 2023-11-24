using System.Globalization;
using BookStoreApp.src.Chirp.CSVDB;
using CsvHelper;

namespace Tests;

public class Chirp_CSVDB_Tests
{
    const string path = @"C:\Users\Madso\BookStoreApp\BookStoreApp\sdata\chirp_cli_db.csv";
    [Theory]
    [InlineData("Madso", "wow how can life be this good")]
    public void See_If_Read_Prints_Correct_Output_From_CSVFile(string author, string message)
    {
        //Arrange
        var dataBase = new CSVDatabase(path);
        //Act
        var readData = dataBase.Read(1);
        var readDataList = readData.ToList();
        //Assert
        Assert.Contains(author,readDataList[0].Author);
        Assert.Contains(message, readDataList[0].Message);
    }
    [Theory]
    [InlineData("MadsOrfelt","Herrow everybody")]
    public void Store_WritesRecordToCsv(string name, string message)
    {
        // Arrange
        var writer = new CSVDatabase(path);
        var recordToStore = new Cheeps
        {
            Author = name,
            Message = message,
            Timestamp = DateTime.Now
        };

        // Act
        writer.Store(recordToStore);

        // Assert
        var storedRecords = ReadRecordsFromCsv(path);
        Assert.NotNull(storedRecords);
        Assert.Contains(storedRecords, r => r.Author == name && r.Message == message);
    }

    private List<Cheeps> ReadRecordsFromCsv(string filePath)
    {
        using (var reader = new StreamReader(filePath))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            return csv.GetRecords<Cheeps>().ToList();
        }
    }
}