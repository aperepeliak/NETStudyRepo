using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _007___CarEventsWithLambdas
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**** Car with lambdas ****\n");

            Car c1 = new Car("SlugBug", 100, 10);

            // Hook into events with lambdas
            // Note: if a method or prop consits of one lineof code curly brackets might be omitted
            c1.AboutToBlow += (sender, e) => Console.WriteLine(e.msg);
            c1.AboutToBlow += (sender, e) => { Console.WriteLine($"Another message: {e.msg}"); };
            c1.Exploded += (sender, e) => Console.WriteLine(e.msg);

            Console.WriteLine("Speeding up");
            for (int i = 0; i < 6; i++)
            {
                c1.Accelerate(20);
            }
        }
    }
}
