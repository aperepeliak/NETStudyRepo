using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002_StringsAndDates
{
    class Program
    {
        static void Main(string[] args)
        {
            // Excercise1();
            // Excercise2();
            // Excercise3();
            // Excercise4();
            Excercise5();
        }

        private static void Excercise1()
        {
            Console.Write("Enter numbers separated by a hyphen: ");

            var numbers = Console.ReadLine()
                                 .Split('-')
                                 .Select(n => int.Parse(n))
                                 .ToList();

            bool flag = true;
            for (int i = 0, j = 1; i < numbers.Count - 1; i++, j++)
            {
                if (numbers[i] - numbers[j] != 1 && numbers[i] - numbers[j] != -1)
                    flag = false;
            }

            Console.WriteLine($"{(flag == true ? "Consecutive" : "Not Consecutive")}");
        }

        private static void Excercise2()
        {
            Console.Write("Enter numbers separated by a hyphen: ");

            var input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input)) return;

            var numbers = input.Split('-')
                               .Select(c => int.Parse(c))
                               .ToList();

            bool hasDuplicate = false;
            for (int i = 0; i < numbers.Count - 1; i++)
            {
                for (int j = i + 1; j < numbers.Count; j++)
                {
                    if (numbers[i] == numbers[j])
                    {
                        hasDuplicate = true;
                        break;
                    }
                }
            }

            if (hasDuplicate == true)
                Console.WriteLine("Duplicate");
        }

        private static void Excercise3()
        {
            Console.Write("Enter a time value: ");
            var input = Console.ReadLine();

            var buffer = input.Split(':');

            var hours = int.Parse(buffer[0]);
            var minutes = int.Parse(buffer[1]);

            if (hours >= 0 && hours <= 23 && minutes >= 0 && minutes <= 59)
                Console.WriteLine("OK");
            else
                Console.WriteLine("Invalid time");
        }

        private static void Excercise4()
        {
            Console.Write("Enter words separated by a space: ");
            var input = Console.ReadLine();

            var words = input.Split(' ')
                             .Select(w => char.ToUpper(w[0]) + w.ToLower().Substring(1))
                             .ToList();

            var varNamePascale = string.Join("", words);

            Console.WriteLine("New var name : " + varNamePascale);
        }

        private static void Excercise5()
        {
            Console.Write("Enter English word : ");
            var numberOfVowels = Console.ReadLine()
                                        .Count(c => "aeoui".Contains(c));

            Console.WriteLine("Number of vowels : " + numberOfVowels);
        }
    }
}
