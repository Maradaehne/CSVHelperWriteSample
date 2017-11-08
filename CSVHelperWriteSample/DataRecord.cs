using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration;

namespace CSVHelperWriteSample
{
    class DataRecord
    {
        public String CommonName { get; set; }
        public String FormalName { get; set; }
        public String TelephoneCode { get; set; }
        public String CountryCode { get; set; }
    }

    public class BeispielRecord
    {
        public String Spalte1 { get; set; }
        public String Spalte2 { get; set; }
        public String Spalte3 { get; set; }
        public String Spalte4 { get; set; }
    }

    public sealed class BeispielRecordMap : ClassMap<BeispielRecord>
    {
        public BeispielRecordMap()
        {
            Map(m => m.Spalte1).Name("Spalte 1");
            Map(m => m.Spalte2).Name("Spalte 2");
            Map(m => m.Spalte3).Name("Spalte 3");
            Map(m => m.Spalte3).Name("Spalte 4");
        }
    }

}
