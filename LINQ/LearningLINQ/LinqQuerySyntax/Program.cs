using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqQuerySyntax
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = {"Pavel", "Pyotr", "Nazar", "Andrii", "Dimitrii", "Akis", "Rustam", "John",
            "Akhmat", "Volodya", "Artem", "Vasilii"};

            var queryResults = from n in names
                               where n.StartsWith("A")
                               select n;

            Console.WriteLine("Names beginning with A : ");
            foreach (var item in queryResults)
            {
                Console.WriteLine(item);
            }

            //Delay
            Console.ReadKey();
        }
    }
}
