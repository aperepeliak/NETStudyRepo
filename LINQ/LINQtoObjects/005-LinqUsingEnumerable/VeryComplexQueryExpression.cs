using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _005_LinqUsingEnumerable
{
    class VeryComplexQueryExpression
    {
        public static void QueryStringsWithRawDelegates()
        {
            Console.WriteLine("**** Using raw Delegates ****");

            string[] books = { "ASP.NET", "CLR via C#", ".NET Framework 4.6", "Entity Framework 6", "WPF" };

            // Build the necessary Func<> delegates
            Func<string, bool> searchFilter = new Func<string, bool>(Filter);
            Func<string, string> itemToProcess = new Func<string, string>(ProcessItem);

            // Pass the delegates intio the methods of Enumerable
            var subset = books
                .Where(searchFilter)
                .OrderBy(itemToProcess)
                .Select(itemToProcess);

            foreach (var b in subset)
                Console.WriteLine($"Item: {b}");
        }

        // Delegate targets
        public static bool Filter(string s) { return s.Contains(" "); }
        public static string ProcessItem(string s) { return s; }
    }
}
