using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _003___DelegateGroupConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Method group conversion\n");

            Car c1 = new Car("Judy", 100, 50);

            // Register the method name
            c1.RegisterWithCarEngine(CallMeHere);

            Console.WriteLine("**** Speeding up ****");
            for (int i = 0; i < 6; i++)
            {
                c1.Accelerate(10);
            }
        }

        static void CallMeHere(string msg)
        {
            Console.WriteLine($" => Message from Car: {msg}");
        }
    }
}
