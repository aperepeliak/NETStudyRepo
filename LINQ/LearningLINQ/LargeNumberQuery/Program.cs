using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LargeNumberQuery
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = GenerateLotsOfNumbers(12045678);

            var queryResult = from n in numbers
                              where n < 1000
                              select n;

            Console.WriteLine("Numbers less than 1000 : ");

            foreach (var n in queryResult)
            {
                Console.WriteLine(n);
            }

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
