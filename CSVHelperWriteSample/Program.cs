using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;

namespace CSVHelperWriteSample
{
    class Program
    {
        static void Main(string[] args)
        {
            //using (var sr = new StreamReader(@"countrylist.csv"))
            //{
            //    using (var sw = new StreamWriter(@"countrylistoutput.csv"))
            //    {

            using (var sr = new StreamReader(@"Beispiel.csv"))
            {
                using (var sw = new StreamWriter(@"Beispieloutput.csv"))
                {


                    var reader = new CsvReader(sr);
                    var writer = new CsvWriter(sw);
                    var config = reader.Configuration;
                    config.Delimiter = "\t";
                    config.Encoding = Encoding.UTF8;
                    config.HasHeaderRecord = true;
                    reader.Configuration.RegisterClassMap<BeispielRecordMap>();

                    //CSVReader will now read the whole file into an enumerable
                    IEnumerable records = reader.GetRecords<BeispielRecord>().ToList();

                    //Write the entire contents of the CSV file into another
                    writer.WriteRecords(records);


                    //Now we will write the data into the same output file but will do it 
                    //Using two methods.  The first is writing the entire record.  The second
                    //method writes individual fields.  Note you must call NextRecord method after 
                    //using Writefield to terminate the record.

                    //Note that WriteRecords will write a header record for you automatically.  If you 
                    //are not using the WriteRecords method and you want to a header, you must call the 
                    //Writeheader method like the following:
                    //
                    //writer.WriteHeader<DataRecord>();
                    //
                    //Do not use WriteHeader as WriteRecords will have done that already.

                    foreach (DataRecord record in records)
                    {
                        //Write entire current record
                        writer.WriteRecord(record);

                        //write record field by field
                        writer.WriteField(record.CommonName);
                        writer.WriteField(record.FormalName);
                        writer.WriteField(record.TelephoneCode);
                        writer.WriteField(record.CountryCode);
                        //ensure you write end of record when you are using WriteField method
                        writer.NextRecord();
                    }
                }
            }
        }
    }
}
