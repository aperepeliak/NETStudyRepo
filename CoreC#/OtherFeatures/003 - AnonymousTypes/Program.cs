using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _003___AnonymousTypes
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        static void BuildAnonType(string make, string color, int currSp)
        {
            // Anonymous type definition
            var car = new { Make = make, Color = color, Speed = currSp };

            // Anonymous type usage
            Console.WriteLine($"You have a {car.Color} {car.Make} going {car.Speed} MPH");

        }
    }
}
