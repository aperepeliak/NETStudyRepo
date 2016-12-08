using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _004_OrderFilterProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var cars = ProcessFile("fuel.csv");

            // Show all
            //foreach (var car in cars)
            //    Console.WriteLine($"{car}");

            Console.WriteLine("Car with the best fuel efficiency");
            var fuelEffQuery = cars.OrderByDescending(c => c.Combined)
                                    .ThenBy(c => c.Name);

            // same query syntax
            var fuelEffQuery2 = from car in cars
                                orderby car.Combined descending, car.Name ascending
                                select car;

            foreach (var car in fuelEffQuery.Take(10))
                Console.WriteLine(car);
            Console.WriteLine(new string('*', 110));

            var result = cars.Any(c => c.Manufacturer == "Ford");
            Console.WriteLine($"Is there any manufacturer Ford: {result}");

            var result2 = cars.All(c => c.Manufacturer == "Ford");
            Console.WriteLine($"Do all of the cars are Ford: {result2}");

            Console.WriteLine(new string('*', 110));

            var charactersQuery = cars.SelectMany(c => c.Name)
                .OrderBy(c => c)
                .Distinct();

            foreach (var character in charactersQuery)
            {
                Console.Write(character);
                Console.Write("\t");
            }
            Console.WriteLine();

        }

        private static List<Car> ProcessFile(string path)
        {
            // Query syntax
            return
                (from line in File.ReadAllLines(path).Skip(1)
                 where line.Length > 1
                 select Car.ParseFromCsv(line))
                .ToList();

            // Method syntax

            //File.ReadAllLines(path)
            //.Skip(1)
            //.Where(line => line.Length > 1)
            //.Select(Car.ParseFromCsv)
            //.ToList();
        }
    }
}
