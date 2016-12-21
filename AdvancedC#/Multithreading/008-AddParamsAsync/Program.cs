using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _008_AddParamsAsync
{
    class Program
    {
        static void Main(string[] args)
        {
            AddAsync();
            Console.ReadLine();
        }

        private static async void AddAsync()
        {
            Console.WriteLine($"ID of thread in Main() : {Thread.CurrentThread.ManagedThreadId}");
            AddParams ap = new AddParams() { A = 10, B = 20 };
            await Sum(ap);

            Console.WriteLine("Other thread is done!");
        }

        private static async Task Sum(AddParams data)
        {
            await Task.Run(() =>
            {
                if (data is AddParams)
                {
                    Console.WriteLine($"ID of thread in Add(): {Thread.CurrentThread.ManagedThreadId}");

                    AddParams ap = data;
                    Console.WriteLine($"{ap.A} + {ap.B} = {ap.A + ap.B}");
                }
            });
        }
    }
}
