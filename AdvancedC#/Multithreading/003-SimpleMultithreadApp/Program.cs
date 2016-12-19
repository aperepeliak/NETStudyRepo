using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _003_SimpleMultithreadApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Thread APP *****\n");
            Console.Write("Do you want [1] or [2] threads? -> ");
            string threadCount = Console.ReadLine();

            Thread primaryThread = Thread.CurrentThread;
            primaryThread.Name = "Primary";

            Console.WriteLine($" -> {Thread.CurrentThread.Name} is executing Main()");

            Printer p = new Printer();

            switch(threadCount)
            {
                case "2":
                    Thread bgThread = new Thread(p.PrintNumbers);
                    bgThread.Name = "Secondary";
                    bgThread.Start();
                    break;
                case "1":
                    p.PrintNumbers();
                    break;
                default:
                    Console.WriteLine("I don't know what you want ... you get 1 thread");
                    goto case "1";
            }
            System.Windows.Forms.MessageBox.Show("I'm busy!", "Work on main thread ...");
        }
    }
}
