using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _005_LinqUsingEnumerable
{
    class Program
    {
        static void Main(string[] args)
        {
            // QueryStringsWithEnumerableAndLabmdas();
            // QueryStringWithAnonymousMethods();

            VeryComplexQueryExpression.QueryStringsWithRawDelegates();
        }

        static void QueryStringWithOperators()
        {
            Console.WriteLine("**** Using query operators ****\n");

            string[] books = { "ASP.NET", "CLR via C#", ".NET Framework 4.6", "Entity Framework 6", "WPF" };

            var subset = from b in books
                         where b.Contains(" ")
                         orderby b
                         select b;

            foreach (var b in subset)
                Console.WriteLine($"Item: {b}");
        }

        static void QueryStringsWithEnumerableAndLabmdas()
        {
            Console.WriteLine("**** Using Enumerable / Lambda Expresions ****");
            string[] books = { "ASP.NET", "CLR via C#", ".NET Framework 4.6", "Entity Framework 6", "WPF" };

            // Build a query expression using extension methods
            // granted to the Array via the Enumerable type
            var subset = books.Where(book => book.Contains(" "))
                .OrderBy(book => book)
                .Select(book => book);

            foreach (var b in subset)
                Console.WriteLine($"Item: {b}");
        }

        static void QueryStringWithAnonymousMethods()
        {
            Console.WriteLine("**** Using Anonymous Methods ****");
            string[] books = { "ASP.NET", "CLR via C#", ".NET Framework 4.6", "Entity Framework 6", "WPF" };

            // Build the necessary Func<> delegates using anonymous methods
            Func<string, bool> searchFilter =
                delegate (string book) { return book.Contains(" "); };

            Func<string, string> itemToProcess =
                delegate (string s) { return s; };

            // Pass the delegates into the methods of Enumerable
            var subset = books.Where(searchFilter)
                .OrderBy(itemToProcess)
                .Select(itemToProcess);

            foreach (var b in subset)
                Console.WriteLine($"Item: {b}");
        }


    }
}
