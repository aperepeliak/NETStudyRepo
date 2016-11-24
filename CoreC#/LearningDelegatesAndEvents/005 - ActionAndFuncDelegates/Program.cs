using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _005___ActionAndFuncDelegates
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Delegates out of the box");

            Action<string, ConsoleColor, int> actionTarget =
                new Action<string, ConsoleColor, int>(DisplayMessage);

            actionTarget("Action Message!", ConsoleColor.Yellow, 5);

            Console.WriteLine(new string('-', 20));

            //Func<int, int, int> funcTarget = new Func<int, int, int>(Add);

            // Using method conversion syntax
            Func<int, int, int> funcTarget = Add;

            int result = funcTarget(5, 9);
            Console.WriteLine($"result: {result}");

            Func<int, int, string> funcTarget2 = SumToString;
            Console.WriteLine($"SumTostring res: {SumToString(1, 3)}");
        }

        static void DisplayMessage(string msg, ConsoleColor txtColor, int printCount)
        {
            ConsoleColor previous = Console.ForegroundColor;
            Console.ForegroundColor = txtColor;

            for (int i = 0; i < printCount; i++)
            {
                Console.WriteLine(msg);
            }

            Console.ForegroundColor = previous;
        }

        static int Add(int x, int y) => x + y;
        static string SumToString(int x, int y) => (x + y).ToString();
    }
}
