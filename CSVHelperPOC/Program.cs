using CsvHelper;
using System;
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
            var startTime = DateTime.Now;
            using (var stream = new StreamWriter(@"..\..\..\Files\ResultFile.csv"))
            using (var csv2 = new CsvWriter(stream))
            {
                csv2.WriteField(nameof(TestObject.Id));
                csv2.WriteField(nameof(TestObject.UserIdentifier));
                csv2.WriteField(nameof(TestObject.AnotherProprety));
                csv2.WriteField(nameof(TestObject.UniqueIdentifier));
                foreach (var item2 in records[0].ExternalPrameters)
                {
                    csv2.WriteField(item2.ParameterName);
                }
                csv2.WriteField(nameof(TestObject2.Status));
                csv2.WriteField(nameof(TestObject2.Result));
                csv2.NextRecord();

                for (int i = 0; i < 50000; i++)
                {
                    csv2.WriteField(nameof(TestObject.Id) + i);
                    csv2.WriteField(nameof(TestObject.UserIdentifier) + i);
                    csv2.WriteField(nameof(TestObject.AnotherProprety) + i);
                    csv2.WriteField(nameof(TestObject.UniqueIdentifier) + i);
                    foreach (var item2 in records[0].ExternalPrameters)
                    {
                        csv2.WriteField(item2.ParameterName + i);
                    }
                    csv2.WriteField(nameof(TestObject2.Status) + i);
                    csv2.WriteField(nameof(TestObject2.Result) + i);
                    csv2.NextRecord();
                }

            }
            var duration = DateTime.Now - startTime;

            List<TestObject> records2;
            //read csv
            var startReadTime = DateTime.Now;
            using (StreamReader reader = File.OpenText(@"..\..\..\Files\ResultFile.csv"))
            using (var csv = new CsvReader(reader))
            {
                csv.Configuration.RegisterClassMap<MapperClass>();
                records2 = csv.GetRecords<TestObject>().ToList();

            }
            var readDuration = DateTime.Now - startReadTime;
        }
    }
}
