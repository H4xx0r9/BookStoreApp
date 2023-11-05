
using System.Globalization;
using CsvHelper;

namespace BookStoreApp.SimpleDB
{
    public sealed class CSVDatabase : IDatabaseRepository<Cheeps>
    {
        public readonly string CsvFilePath;

        public CSVDatabase(string filePath)
        {
            CsvFilePath = filePath;
        }

        public IEnumerable<Cheeps> Read(int? limit = null)
        {
            using var sr = new StreamReader(CsvFilePath);
            using var csv = new CsvReader(sr, CultureInfo.InvariantCulture);
            var records = csv.GetRecords<Cheeps>().ToList();

            if (limit.HasValue)
            {
                records = records.Take(limit.Value).ToList();
            }

            return records;
        }

        public void Store(Cheeps record)
        {
            using var writer = new StreamWriter(CsvFilePath, true);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            
            csv.WriteRecord(record);
            csv.Flush();
            writer.WriteLine();
        }
    }
}