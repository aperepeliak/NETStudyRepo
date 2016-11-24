using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _003___GenericEventHandler
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Generic EventHandler<T>");

            Car c1 = new Car("SlugBug", 100, 10);

            c1.AboutToBlow += CarIsAlmostDoomed;
            c1.AboutToBlow += CarAboutToBlow;
            c1.Exploded += CarExploded;

            Console.WriteLine("**** Speeding up ****");
            for (int i = 0; i < 6; i++)
            {
                c1.Accelerate(20);
            }

            c1.Exploded -= CarExploded;

            Console.WriteLine("\n**** Speeding UP! ****\n");
            for (int i = 0; i < 6; i++)
            {
                c1.Accelerate(20);
            }
        }

        private static void CarExploded(object sender, CarEventArgs args)
        {
            Console.WriteLine($"{sender} says : {args.msg}");
        }

        private static void CarAboutToBlow(object sender, CarEventArgs args)
        {
            if (sender is Car)
            {
                Car tmp = (Car)sender;
                Console.WriteLine($"Message from : {tmp.PetName} --> {args.msg}");
            }
        }

        private static void CarIsAlmostDoomed(object sender, CarEventArgs args)
        {
            if (sender is Car)
            {
                Console.WriteLine($" => This is {(((Car)sender).PetName).ToUpper()}. {args.msg}");
            }
        }
    }
}
