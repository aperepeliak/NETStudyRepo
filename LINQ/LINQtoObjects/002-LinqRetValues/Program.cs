using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002_LinqRetValues
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("LINQ Return values\n");
            IEnumerable<string> subset = GetStringSubset();

            foreach (string item in subset)
                Console.WriteLine(item);

            Console.WriteLine("######");
            foreach(var item in GetStringSubsetAsArray())
                Console.WriteLine(item);

        }

        private static IEnumerable<string> GetStringSubset()
        {
            string[] colors = { "Yellow", "Blue", "Green", "Black", "Pink", "Dark Red", "Light Red" };

            IEnumerable<string> theRedColors = from c in colors
                                               where c.Contains("Red")
                                               select c;

            return theRedColors;
        }

        // Using immediate execution
        static string[] GetStringSubsetAsArray()
        {
            string[] colors = { "Yellow", "Blue", "Green", "Black", "Pink", "Dark Red", "Light Red" };
            var theRedColors = from c in colors
                               where c.Contains("Red")
                               select c;

            return theRedColors.ToArray();   
        }
    }
}
