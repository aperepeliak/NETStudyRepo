using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComparableCar
{
    class Program
    {
        static void Main(string[] args)
        {
            Car[] myAutos = new Car[] {
                new Car("Daisy", 60, 12),
                new Car("Philly", 50, 5),
                new Car("Mary", 55, 10),
                new Car("Mike", 43, 23)
            };

            Console.WriteLine("Before sort: ");
            foreach (Car car in myAutos)
            {
                Console.WriteLine($"{car.CarID}\t{car.PetName}");
            }

            Array.Sort(myAutos);

            Console.WriteLine($"\nAfter sort #1: ");
            foreach (Car car in myAutos)
            {
                Console.WriteLine($"{car.CarID}\t{car.PetName}");
            }

            //Array.Sort(myAutos, new PetNameComparer());

            // Sorting is now more clear and understandable
            Array.Sort(myAutos, Car.SortByPetName);
            Console.WriteLine($"\nAfter sort #2: ");
            foreach (Car car in myAutos)
            {
                Console.WriteLine($"{car.CarID}\t{car.PetName}");
            }
        }
    }
}
