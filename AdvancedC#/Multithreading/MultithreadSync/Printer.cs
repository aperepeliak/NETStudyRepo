using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultithreadSync
{
    public class Printer
    {
        // Lock token
        private object threadLock = new object();

        public void PrintNumbers()
        {

            lock (threadLock)
            {
                Console.WriteLine($" -> {Thread.CurrentThread.Name} is executing PrintNumbers()");

                Console.Write("Your numbers: ");
                for (int i = 0; i < 10; i++)
                {
                    Random r = new Random();
                    Thread.Sleep(1000 * r.Next(5));
                    Console.Write($"{i}, ");
                }
                Console.WriteLine();
            }
        }
    }
}
