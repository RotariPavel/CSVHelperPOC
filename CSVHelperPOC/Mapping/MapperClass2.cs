using CsvHelper.Configuration;

namespace CSVHelperPOC
{
    public class MapperClass2 : ClassMap<TestObject2>
    {
        public MapperClass2()
        {
            References<MapperClass>(p => p.Original);
            Map(p => p.Status);
            Map(p => p.Result);

        }
    }
}
