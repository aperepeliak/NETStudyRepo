using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_LinqOverQuery
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"***** Learning LINQ to Objects *****\n");

            QueryOverStrings();
            QueryOverInts();
        }

        private static void QueryOverInts()
        {
            int[] numbers = { 10, 20, 30, 40, 1, 2, 3, 5, 8 };

            // Print only items less than 10
            var subset = from i in numbers
                                      where i < 10
                                      select i;

            foreach(var i in subset)
                Console.WriteLine($"Item: {i}");

            ReflectOverQueryResults(subset);
        }

        static void QueryOverStrings()
        {
            string[] books = { "ASP.NET 5", "Entity Framework 6", "WPF", "CLR", "C#" };

            // Find the items in the array that have an embedded space
            IEnumerable<string> subset = from book in books
                                         where book.Contains(" ")
                                         orderby book
                                         select book;

            // Result
            foreach (string s in subset)
            {
                Console.WriteLine($"Item: {s}");
            }

            ReflectOverQueryResults(subset);
        }

        static void ReflectOverQueryResults(object resultSet)
        {
            Console.WriteLine($"\n==== Info about your query ====\n");
            Console.WriteLine($"resultSet is of type: {resultSet.GetType().Name}");
            Console.WriteLine($"resultSet location  : {resultSet.GetType().Assembly.GetName().Name}");
            Console.WriteLine($"\n==== END ====\n");
        }
    }
}
