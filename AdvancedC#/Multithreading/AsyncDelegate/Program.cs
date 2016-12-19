using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncDelegate
{

    public delegate int BinaryOp(int x, int y);

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Main() invoked on thread {Thread.CurrentThread.ManagedThreadId}");
            BinaryOp b = Add;
            IAsyncResult res = b.BeginInvoke(10, 10, null, null);

            // while (!res.AsyncWaitHandle.WaitOne(1000, true)) ...
            while(!res.IsCompleted)
            {
                Console.WriteLine("Doing more work in Main()!");
                Thread.Sleep(1000);
            }
            int answer = b.EndInvoke(res);
            Console.WriteLine($"10 + 10 = {answer}");
        }

        static int Add(int x, int y)
        {
            Console.WriteLine($"Add() invoked on thread {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(3000);
            return x + y;
        }
    }
}
