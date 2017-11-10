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
                csv.Configuration.DetectColumnCountChanges = true;

                records = csv.GetRecords<TestObject>().ToList();

            }

            //write csv
            //using (var stream = new StreamWriter(@"..\..\..\Files\ResultFile.csv"))
            //using (var csv2 = new CsvWriter(stream))
            //{
            //    csv2.Configuration.RegisterClassMap<MapperClass2>();
            //    csv2.WriteRecords(records);

            //}

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

                foreach (var item in records)
                {
                    csv2.WriteField(item.Id);
                    csv2.WriteField(item.UserIdentifier);
                    csv2.WriteField(item.AnotherProprety);
                    csv2.WriteField(item.UniqueIdentifier);
                    foreach (var item2 in item.ExternalPrameters)
                    {
                        csv2.WriteField(item2.ParameterValue);
                    }
                    csv2.WriteField("status1");
                    csv2.WriteField("result1");
                    csv2.NextRecord();
                }

            }



        }
    }
}
