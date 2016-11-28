using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _004___AnonymousMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**** Anonymous methods *****\n");
            int aboutToBlowCounter = 0;

            Car c1 = new Car("SlugBug", 100, 10);

            // Register event handlers as anonymous methods
            c1.AboutToBlow += delegate
            {
                aboutToBlowCounter++;
                Console.WriteLine("Going to fast!!");
            };

            c1.AboutToBlow += delegate (object sender, CarEventArgs e)
            {
                aboutToBlowCounter++;
                Console.WriteLine($"Message from Car: {e.msg}");
            };

            c1.Exploded += delegate (object sender, CarEventArgs e)
            {
                Console.WriteLine($"Fatal Message from Car: {e.msg}");
            };

            for (int i = 0; i < 6; i++)
                c1.Accelerate(20);

            Console.WriteLine(new string('-', 20));
            Console.WriteLine($"aboutToBlow event was fired {aboutToBlowCounter} times.");
        }
    }
}
