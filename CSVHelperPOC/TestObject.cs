using System.Collections.Generic;

namespace CSVHelperPOC
{
    public class TestObject
    {
        public string Id { get; set; }
        public string UserIdentifier { get; set; }
        public string AnotherProprety { get; set; }
        public string UniqueIdentifier { get; set; }

        public IEnumerable<ExternalParameters> ExternalPrameters { get; set; }
    }

    public class ExternalParameters
    {
        public string ParameterName { get; set; }
        public string ParameterValue { get; set; }
    }
}