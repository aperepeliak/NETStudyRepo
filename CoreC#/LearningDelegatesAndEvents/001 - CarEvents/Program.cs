using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001___CarEvents
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Learning events");

            Car c1 = new Car("SlugBug", 100, 10);

            // Regestering event handlers
            // c1.AboutToBlow += new Car.CarEngineHandler(CarIsAlmostDoomed);

            // Using method group conversion
            c1.AboutToBlow += CarIsAlmostDoomed;
            c1.AboutToBlow += CarAboutToBlow;

            //Car.CarEngineHandler d = new Car.CarEngineHandler(CarExploded);
            //c1.Exploded += d;

            c1.Exploded += CarExploded;

            Console.WriteLine("**** Speeding up ****");
            for (int i = 0; i < 6; i++)
            {
                c1.Accelerate(20);
            }

            // Removing CarExploded method from invocation list
            // c1.Exploded -= d;

            c1.Exploded -= CarExploded;

            Console.WriteLine("\n**** Speeding UP! ****\n");
            for (int i = 0; i < 6; i++)
            {
                c1.Accelerate(20);
            }
        }

        private static void CarExploded(string msg)
        {
            Console.WriteLine(msg);
        }

        private static void CarAboutToBlow(string msg)
        {
            Console.WriteLine(msg);
        }

        private static void CarIsAlmostDoomed(string msg)
        {
            Console.WriteLine($" => Critical Message from Car: {msg}");
        }
    }
}
