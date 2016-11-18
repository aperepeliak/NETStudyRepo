using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomEnumerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Garage carLot = new Garage();

            foreach (Car car in carLot)
            {
                Console.WriteLine($"{car.PetName} is going {car.CurrSpeed} MPH");
            }

            // Manually work with IEnumerator
            IEnumerator i = carLot.GetEnumerator();
            i.MoveNext();
            Car myCar = (Car)i.Current;
            Console.WriteLine($"My car: {myCar.PetName} speed: {myCar.CurrSpeed}");
        }
    }
}
