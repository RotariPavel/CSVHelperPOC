using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CSVHelperPOC
{
    public class ExtParamsMap : ClassMap<ExternalParameters>
    {
        //public ExtParamsMap(Dictionary<string, Expression<Func<ExternalParameters, object>>> parameters)
        //{
        //    foreach (var item in parameters)
        //    {
        //        Map(item.Value).Name(item.Key);
        //    }
        //}

        public ExtParamsMap()
        {
            
        }
    }
}
