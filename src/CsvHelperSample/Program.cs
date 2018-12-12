using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;

namespace CsvHelperSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var list = ReadCsv();
            foreach (var item in list)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadKey();
        }

        private static List<CsvItem> ReadCsv()
        {
            using (var reader = new StreamReader(@".\sample.csv", Encoding.UTF8))
            using (var csv = new CsvReader(reader))
            {
                csv.Configuration.HasHeaderRecord = true;
                csv.Configuration.RegisterClassMap<CsvItemMap>();
                return csv.GetRecords<CsvItem>().ToList();
            }
        }
    }


    public sealed class CsvItemMap : ClassMap<CsvItem>
    {
        public CsvItemMap()
        {
            Map(m => m.Header.Title).Index(0);
            Map(m => m.PersonList).ConvertUsing(row =>
            {
                var list = new List<Person>();

                var index = 1;
                for (var i = 0; i < 3; i++)
                {
                    var person = new Person()
                    {
                        LastName = row.GetField(index++),
                        FirstName = row.GetField(index++),
                        Age = int.Parse(row.GetField(index++)),
                    };
                    list.Add(person);
                }


                return list;
            });
        }
    }
}
