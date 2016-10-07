using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aggregateOperators
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = GenerateLotsOfNumbers(12345678);

            var queryResult = from n in numbers
                              where n > 1000
                              select n;

            Console.Write("Count\t\t:");
            Console.WriteLine(queryResult.Count());

            Console.Write("Max\t\t:");
            Console.WriteLine(queryResult.Max());

            Console.Write("Min\t\t:");
            Console.WriteLine(queryResult.Min());

            Console.Write("Average\t\t:");
            Console.WriteLine(queryResult.Average());

            Console.Write("Sum\t\t:");
            Console.WriteLine(queryResult.Sum(n => (long) n));

            Console.ReadKey();
        }

        private static int[] GenerateLotsOfNumbers(int count)
        {
            Random generator = new Random(0);

            int[] result = new int[count];

            for (int i = 0; i < count; i++)
            {
                result[i] = generator.Next();
            }
            return result;
        }
    }
}
