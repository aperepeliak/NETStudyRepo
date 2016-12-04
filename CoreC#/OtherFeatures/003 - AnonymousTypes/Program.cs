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
            var myCar = new { Color = "Bright Pink", Make = "Saab", CurrentSpeed = 55 };
            Console.WriteLine($"MyCar: {myCar.Color} {myCar.Make}");

            BuildAnonType("BMW", "Black", 60);
            Console.WriteLine("-------------");

            ReflectOverAnonymousType(myCar);
            EqualityTest();


            // Composite anonymous types
            var purchaseItem = new
            {
                TimeBought = DateTime.Now,
                ItemBought = new { Color = "Red", Make = "Saab", CurrentSpeed = "55" },
                Price = 34.000
            };

            ReflectOverAnonymousType(purchaseItem);
        }

        static void BuildAnonType(string make, string color, int currSp)
        {
            // Anonymous type definition
            var car = new { Make = make, Color = color, Speed = currSp };

            // Anonymous type usage
            Console.WriteLine($"You have a {car.Color} {car.Make} going {car.Speed} MPH");
        }

        static void ReflectOverAnonymousType(object obj)
        {
            Console.WriteLine($"obj is an instance of: {obj.GetType().Name}");

            Console.WriteLine("Base class of {0} is {1}",
                obj.GetType().Name,
                obj.GetType().BaseType);

            Console.WriteLine($"obj.ToString() == {obj.ToString()}");
            Console.WriteLine($"obj.GetHashCode() == {obj.GetHashCode()}");
            Console.WriteLine("--------------------");
        }

        static void EqualityTest()
        {
            Console.WriteLine("\n***** Equality test method START *****\n");
            var car1 = new { Color = "Bright Pink", Make = "Saab", CurrentSpeed = 55 };
            var car2 = new { Color = "Bright Pink", Make = "Saab", CurrentSpeed = 55 };

            // Are they equal using Equals()?
            if (car1.Equals(car2))
                Console.WriteLine("Same anonymous objects! (EQUALS)");
            else
                Console.WriteLine("NOT the same! (EQUALS)");

            // Are they equal using '=='?
            if (car1 == car2)
                Console.WriteLine("Same anonymous objects! ('==')");
            else
                Console.WriteLine("NOT the same! (==)");

            // Are these objects the same underlying type?
            if (car1.GetType().Name == car2.GetType().Name)
                Console.WriteLine("We are both the same type!");
            else
                Console.WriteLine("We are different types!");

            Console.WriteLine("========================");
            ReflectOverAnonymousType(car1);
            ReflectOverAnonymousType(car2);
            Console.WriteLine("\n***** Equality test method END *****\n");
        }
    }
}
