using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqMethodSyntax
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = {"Pavel", "Pyotr", "Nazar", "Andrii", "Dimitrii", "Akis", "Rustam", "John",
            "Akhmat", "Volodya", "Artem", "Vasilii"};

            var queryResults = names.Where(n => n.StartsWith("A"));

            Console.WriteLine("Names beginning with A : ");
            foreach (var item in queryResults)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }
}
