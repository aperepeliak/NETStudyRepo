using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _002_AsyncCallbackDelegate
{
    public delegate int BinaryOp(int x, int y);

    class Program
    {
        private static bool isDone = false;

        static void Main(string[] args)
        {
            Console.WriteLine($"Main() invoked on thread {Thread.CurrentThread.ManagedThreadId}");

            BinaryOp b = Add;

            IAsyncResult res = b.BeginInvoke(10, 10, OnAddComplete, "Message from the Main()");

            while (!isDone)
            {
                Thread.Sleep(1000);
                Console.WriteLine("Working ...");
            }
        }

        private static void OnAddComplete(IAsyncResult res)
        {
            Console.WriteLine($"OnAddComplete invoked on thread {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine("Addition is complete");

            var ar = (AsyncResult)res;
            var b = (BinaryOp)ar.AsyncDelegate;
            Console.WriteLine($"10 + 10 is {b.EndInvoke(res)}");
            string message = (string)res.AsyncState;
            Console.WriteLine(message);

            isDone = true;
        }

        private static int Add(int x, int y)
        {
            Console.WriteLine($"Add() invoked on thread {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(5000);
            return x + y;
        }
    }
}
