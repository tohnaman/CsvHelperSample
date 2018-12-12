using System.Collections.Generic;
using System.Text;

namespace CsvHelperSample
{
    public class CsvItem
    {
        public Header Header { get; set; }
        public List<Person> PersonList { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"{this.Header.Title} ");
            foreach (var item in this.PersonList)
            {
                sb.Append($"{item.LastName}{item.FirstName} {item.Age}歳 ");
            }
            return sb.ToString();
        }
    }

    public class Header
    {
        public string Title { get; set; }
    }

    public class Person
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int Age { get; set; }
    }
}
