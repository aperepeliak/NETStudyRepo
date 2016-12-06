using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _003_LinqOverCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** LINQ over generic collections *****\n");

            List<Car> myCars = new List<Car>()
            {
                new Car {PetName = "Henry", Color = "Yellow", Speed = 100, Make = "BMW" },
                new Car {PetName = "Daisy", Color = "Black", Speed = 90, Make = "Toyota" },
                new Car {PetName = "Pippo", Color = "Red", Speed = 40, Make = "Fiat" },
                new Car {PetName = "Carlsen", Color = "White", Speed = 55, Make = "Volvo" },
                new Car {PetName = "Fritz", Color = "Blue", Speed = 95, Make = "BMW" }
            };

            GetFastCars(myCars);
            Console.WriteLine("-----------------");
            GetFastBMWs(myCars);
            Console.WriteLine("-----------------");
            OfTypeAsFilter();
        }

        static void GetFastCars(List<Car> myCars)
        {
            var fastCars = from c in myCars
                           where c.Speed > 55
                           select c;

            foreach (var car in fastCars)
                Console.WriteLine($"{car.PetName} is going to fast!");
        }

        static void GetFastBMWs(List<Car> myCars)
        {
            var fastCars = from c in myCars
                           where c.Speed > 55 && c.Make == "BMW"
                           select c;

            foreach (var car in fastCars)
                Console.WriteLine($"BMW named {car.PetName} is going to fast!");
        }

        static void LinqOverArrayList()
        {
            Console.WriteLine("***** LINQ over ArrayList *****\n");

            // Nongeneric collection of cars
            ArrayList myCars = new ArrayList()
            {
                new Car {PetName = "Henry", Color = "Yellow", Speed = 100, Make = "BMW" },
                new Car {PetName = "Daisy", Color = "Black", Speed = 90, Make = "Toyota" },
                new Car {PetName = "Pippo", Color = "Red", Speed = 40, Make = "Fiat" },
                new Car {PetName = "Carlsen", Color = "White", Speed = 55, Make = "Volvo" },
                new Car {PetName = "Fritz", Color = "Blue", Speed = 95, Make = "BMW" }
            };

            // Transform ArrayList into an Ienumerable<T>-compatible type
            var myCarsEnum = myCars.OfType<Car>();

            var fastCars = from c in myCarsEnum
                           where c.Speed > 50
                           select c;

            foreach (var c in fastCars)
                Console.WriteLine($"{c.PetName} is going to fast!");
        }

        static void OfTypeAsFilter()
        {
            // Extract the ints from the ArrayList
            ArrayList myStuff = new ArrayList();
            myStuff.AddRange(new object[] { 10, 400, 8, false, new Car(), 15, "some data" });

            var myInts = myStuff.OfType<int>();

            foreach (var i in myInts)
                Console.WriteLine($"int value: {i}");
        }
    }
}
