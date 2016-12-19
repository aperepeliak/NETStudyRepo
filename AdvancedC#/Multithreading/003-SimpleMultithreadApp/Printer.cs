using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _003_SimpleMultithreadApp
{
    public class Printer
    {
        public void PrintNumbers()
        {
            Console.WriteLine($" -> {Thread.CurrentThread.Name} is executing PrintNumbers()");

            Console.Write("Your numbers: ");
            for (int i = 0; i < 5; i++)
            {
                Console.Write($"{i}, ");
                Thread.Sleep(2000);
            }
            Console.WriteLine();
        }
    }
}
