using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningAttrs
{
    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person
            {
                FirstName = "John",
                LastName = "Doe"
            };

            var output = CsvConvert.ToCsv(person);

            Console.WriteLine(output);
        }
    }
}
