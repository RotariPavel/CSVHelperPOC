using CsvHelper.Configuration;
using System.Linq;

namespace CSVHelperPOC
{
    public sealed class MapperClass : ClassMap<TestObject>
    {
        public MapperClass()
        {
            //AutoMap();
            Map(c => c.Id).Name(nameof(TestObject.Id)).Index(0);
            Map(c => c.UserIdentifier).Name(nameof(TestObject.UserIdentifier)).Index(1);
            Map(c => c.AnotherProprety).Name(nameof(TestObject.AnotherProprety)).Index(2);
            Map(c => c.UniqueIdentifier).Name(nameof(TestObject.UniqueIdentifier)).Index(3);
            Map(c => c.ExternalPrameters).Index(4);
            Map(m => m.ExternalPrameters).ConvertUsing(row =>
            (row.Context?.HeaderRecord)
            .Skip(4)
            .Select(header =>
                new ExternalParameters()
                {
                    ParameterName = header,
                    ParameterValue = row.GetField<string>(header)
                }
            ).ToList());
        }

    }
}
