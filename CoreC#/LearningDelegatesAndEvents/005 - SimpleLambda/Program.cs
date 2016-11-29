
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _005___SimpleLambda
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**** LAMBDAS *****");

            TraditionalDelegateSyntax();
            Console.WriteLine(new string('-', 20));
            AnonymousSyntaxMethod();
            Console.WriteLine(new string('-', 20));
            LambdaExpressionSyntax();
        }

        static void TraditionalDelegateSyntax()
        {
            List<int> list = new List<int>();
            list.AddRange(new int[] { 20, 1, 5, 4, 23, 1, 6, 8 });

            Predicate<int> callback = IsEvenNumber;
            List<int> evenNumbers = list.FindAll(callback);

            Console.WriteLine("[Traditional] Even numbers: ");
            foreach (var num in evenNumbers)
            {
                Console.Write($"{num}\t");
            }
            Console.WriteLine();
        }

        static bool IsEvenNumber(int i)
        {
            return (i % 2) == 0;
        }

        static void AnonymousSyntaxMethod()
        {
            List<int> list = new List<int>();
            list.AddRange(new int[] { 20, 1, 5, 4, 23, 1, 6, 8 });

            List<int> evenNumbers = list.FindAll(delegate (int i) { return (i % 2) == 0; });

            Console.WriteLine("[Anonymous method] Even numbers: ");
            foreach (var num in evenNumbers)
            {
                Console.Write($"{num}\t");
            }
            Console.WriteLine();
        }

        static void LambdaExpressionSyntax()
        {
            List<int> list = new List<int>();
            list.AddRange(new int[] { 20, 1, 5, 4, 23, 1, 6, 8 });

            List<int> evenNumbers = list.FindAll(i => (i % 2) == 0);

            Console.WriteLine("[Lambda expression] Even numbers: ");
            foreach (var num in evenNumbers)
            {
                Console.Write($"{num}\t");
            }
            Console.WriteLine();
        }
    }
}
