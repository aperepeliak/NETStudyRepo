using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_ArraysAndLists
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

        private static void Excercise5()
        {
            var numbers = new List<int>();

            Console.Write("Enter a list of comma separated numbers : ");
            var input = Console.ReadLine();

            var buffer = input.Split(',');

            foreach (var number in buffer)
            {
                numbers.Add(int.Parse(number));
            }

            if (numbers.Count == 0 || numbers.Count < 5)
            {
                Console.WriteLine("Invalid list! Please, retry.");
                return;
            }

            Console.Write("Three smallest numebrs in the list: ");
            numbers.Sort();
            for (int i = 0; i < 3; i++)
            {
                Console.Write($" {numbers[i]} ");
            }
            Console.WriteLine();
        }

        private static void Excercise4()
        {
            var numbers = new List<int>();

            while (true)
            {
                Console.Write("Enter a number : ");
                var input = Console.ReadLine();

                if (string.Equals(input.ToLower(), "quit"))
                    break;

                numbers.Add(int.Parse(input));
            }

            var uniqueNumbers = new List<int>();

            foreach (var n in numbers)
            {
                if (!uniqueNumbers.Contains(n))
                    uniqueNumbers.Add(n);
            }

            Console.WriteLine("Unique numbers: ");
            foreach (var n in uniqueNumbers)
            {
                Console.WriteLine(n);
            }
        }

        private static void Excercise3()
        {
            var numbers = new List<int>(5);

            while (numbers.Count < 5)
            {
                Console.Write("Enter unique number : ");
                var number = int.Parse(Console.ReadLine());

                if (numbers.Contains(number))
                {
                    Console.WriteLine("Error! Please retry.");
                    return;
                }

                numbers.Add(number);
            }

            numbers.Sort();
            foreach (var number in numbers)
                Console.WriteLine(number);
        }

        private static void Excercise2()
        {
            Console.Write("Enter your name : ");
            var name = Console.ReadLine();
            var buffer = name.ToCharArray();
            Array.Reverse(buffer);
            var reversed = new string(buffer);

            Console.WriteLine($"Reversed: {reversed}");
        }

        private static void Excercise1()
        {
            var likes = new List<string>();

            while (true)
            {
                Console.Write("Enter name: ");
                var name = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(name))
                    break;

                likes.Add(name);
            }

            switch (likes.Count)
            {
                case 0:
                    break;

                case 1:
                    Console.WriteLine($"{likes[0]} likes your post");
                    break;

                case 2:
                    Console.WriteLine($"{likes[0]} and {likes[1]} like your post");
                    break;

                default:
                    Console.WriteLine($"{likes[0]}, {likes[1]} and {likes.Count - 2} others like your post");
                    break;
            }
        }
    }
}
