using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002___CarDelegate
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Delegates as event enablers\n");

            Car c1 = new Car("SlugBug", 100, 10);

            // Tell the car which method to call when it wants to send us messages
            c1.RegisterWithCarEngine(new Car.CarEngineHandler(OnCarEngineEvent));

            Car.CarEngineHandler handler2 = new Car.CarEngineHandler(OnCarEngineEventUpper);
            c1.RegisterWithCarEngine(handler2);

            // Speed up (this will trigger the events)
            Console.WriteLine("Speeding up");
            for (int i = 0; i < 6; i++)
            {
                c1.Accelerate(20);
            }

            // Unregister from handler2
            c1.UnregisterWithCarEngine(handler2);
            Console.WriteLine("Speeding up");
            for (int i = 0; i < 6; i++)
            {
                c1.Accelerate(20);
            }
        }

        private static void OnCarEngineEventUpper(string msg)
        {
            Console.WriteLine($"=> {msg.ToUpper()}");
        }

        public static void OnCarEngineEvent(string msg)
        {
            Console.WriteLine("\n**** Message from car Object ****\n");
            Console.WriteLine($"=> {msg}");
            Console.WriteLine("************************\n");
        }
    }
}
