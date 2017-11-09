using CsvHelper;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CSVHelperPOC
{
    class Program
    {
        static void Main(string[] args)
        {
            List<TestObject> records;
            //read csv
            using (StreamReader reader = File.OpenText(@"..\..\..\Files\ActionFile.csv"))
            using (var csv = new CsvReader(reader))
            {
                csv.Configuration.RegisterClassMap<MapperClass>();
                records = csv.GetRecords<TestObject>().ToList();

            }

            //write csv
            using (var stream = new StreamWriter(@"..\..\..\Files\ResultFile.csv"))
            using (var csv = new CsvWriter(stream))
            {
                csv.WriteRecords(records);

            }



        }
    }
}
