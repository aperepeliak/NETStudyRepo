using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _004_TimerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var myTimer = new Timer((state) =>
            { 
                Console.WriteLine($"Time is: {DateTime.Now.ToLongTimeString()} \tState: {state.ToString()}");
            },
            "Hello from Main!",
            0, 1000);

            Console.WriteLine("Hit key to terminate ...");
            Console.ReadKey();
        }
    }
}
