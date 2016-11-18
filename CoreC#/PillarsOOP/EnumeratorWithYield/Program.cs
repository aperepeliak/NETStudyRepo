using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumeratorWithYield
{
    class Program
    {
        static void Main(string[] args)
        {
            Garage carLot = new Garage();

            // Get items using GetEnumerator()
            foreach(Car c in carLot)
            {
                Console.WriteLine($"{c.PetName} is going {c.CurrSpeed} MPH");
            }

            Console.WriteLine();

            // Get items (in reverse) using named iterator.
            foreach (Car c in carLot.GetTheCars(true))
            {
                Console.WriteLine($"{c.PetName} is going {c.CurrSpeed} MPH");
            }
        }
    }
}
