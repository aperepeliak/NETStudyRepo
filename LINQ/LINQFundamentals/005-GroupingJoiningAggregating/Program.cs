using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _005_GroupingJoiningAggregating
{
    class Program
    {
        static void Main(string[] args)
        {
            var cars = ProcessCars("fuel.csv");
            var manufacturers = ProcessManufacturers("manufacturers.csv");

            #region Joins
            /*
            var query = from car in cars
                        join manuf in manufacturers
                        on car.Manufacturer equals manuf.Name
                        orderby car.Combined descending, car.Name ascending
                        select new
                        {
                            manuf.Headquaters,
                            car.Name,
                            car.Combined
                        };

            // Same query using method syntax
            var query2 = cars.Join(manufacturers,
                c => c.Manufacturer,
                m => m.Name,
                (c, m) => new
                {
                    m.Headquaters,
                    c.Name,
                    c.Combined
                })
                .OrderByDescending(c => c.Combined)
                .ThenBy(c => c.Name);


            foreach (var car in query2.Take(10))
                Console.WriteLine($"{car.Headquaters,-15} {car.Name}");
            */
            #endregion

            #region Grouping

            var query =
                from car in cars
                group car by car.Manufacturer.ToUpper() into manuf
                orderby manuf.Key ascending
                select manuf;

            // Extension method syntax analogue
            var query2 =
                cars.GroupBy(c => c.Manufacturer.ToUpper())
                .OrderBy(g => g.Key);



            // Key is value that query is grouped by (in this case by Manufacturer)
            // Key maybe equal Ford, Toyota etc.
            // 
            //foreach (var group in query)
            //{
            //    // Console.WriteLine($"{group.Key,-35} has {group.Count()} cars");

            //    // We can iterate over group
            //    Console.WriteLine($"{group.Key}");
            //    foreach (var car in group.OrderByDescending(c => c.Combined).Take(2))
            //    {
            //        Console.WriteLine($"\t{car.Name,-35} {car.Combined}");
            //    }
            //    Console.WriteLine(new string('=', 50));
            //}
            #endregion

            #region GroupJoin

            var query3 =
                from manuf in manufacturers
                join car in cars on manuf.Name equals car.Manufacturer
                    into carGroup
                orderby manuf.Name
                select new
                {
                    Manufacturer = manuf,
                    Cars = carGroup
                };

            // Same using extension method syntax
            var query4 =
                manufacturers.GroupJoin(
                    cars,
                    m => m.Name,
                    c => c.Manufacturer,
                    (m, cg) => new { Manufacturer = m, Cars = cg }
                )
                .OrderBy(m => m.Manufacturer.Name);

            //foreach (var group in query4)
            //{
            //    Console.WriteLine($"{group.Manufacturer.Name} : {group.Manufacturer.Headquaters}");
            //    foreach (var car in group.Cars.OrderByDescending(c => c.Combined).Take(2))
            //    {
            //        Console.WriteLine($"\t{car.Name,-35} {car.Combined}");
            //    }
            //}

            // Mini-challenge
            var query5 =
                from manuf in manufacturers
                join car in cars on manuf.Name equals car.Manufacturer
                    into carGroup
                select new
                {
                    Manufacturer = manuf,
                    Cars = carGroup
                } into result
                group result by result.Manufacturer.Headquaters.ToUpper();

            // Extension method syntax
            var query6 =
                manufacturers.GroupJoin(
                    cars,
                    m => m.Name,
                    c => c.Manufacturer,
                    (m, g) => new { Manufacturer = m, Cars = g })
               .GroupBy(m => m.Manufacturer.Headquaters);

            //foreach (var group in query6)
            //{
            //    Console.WriteLine($"{group.Key}");
            //    foreach (var car in group
            //        .SelectMany(g => g.Cars)
            //        .OrderByDescending(c => c.Combined)
            //        .Take(3))
            //    {
            //        Console.WriteLine($"\t{car.Name} : {car.Combined}");
            //    }
            //}



            #endregion

            #region Aggregating Data

            var query7 =
                from car in cars
                group car by car.Manufacturer into carGroup
                select new
                {
                    Name = carGroup.Key,
                    Max = carGroup.Max(c => c.Combined),
                    Min = carGroup.Min(c => c.Combined),
                    Avg = carGroup.Average(c => c.Combined)
                } into result
                orderby result.Max descending
                select result;

            foreach (var result in query7)
            {
                Console.WriteLine($"{result.Name}");
                Console.WriteLine($"\tMax: {result.Max}");
                Console.WriteLine($"\tMin: {result.Min}");
                Console.WriteLine($"\tAvg: {result.Avg, 3:N}");
            }

            #endregion

        }

        private static List<Manufacturer> ProcessManufacturers(string path)
        {
            var query = File.ReadAllLines(path)
                .Where(l => l.Length > 1)
                .Select(l =>
                {
                    var columns = l.Split(',');
                    return new Manufacturer
                    {
                        Name = columns[0],
                        Headquaters = columns[1],
                        Year = int.Parse(columns[2])
                    };
                });

            return query.ToList();
        }

        private static List<Car> ProcessCars(string path)
        {

            var query = File.ReadAllLines(path)
                            .Skip(1)
                            .Where(l => l.Length > 1)
                            .ToCar();

            return query.ToList();
        }
    }

    static class MyExtensions
    {
        public static IEnumerable<Car> ToCar(this IEnumerable<string> source)
        {
            foreach (var line in source)
            {
                var columns = line.Split(',');

                yield return new Car
                {
                    Year = int.Parse(columns[0]),
                    Manufacturer = columns[1],
                    Name = columns[2],
                    Displacement = double.Parse(columns[3], CultureInfo.InvariantCulture),
                    Cylinders = int.Parse(columns[4]),
                    City = int.Parse(columns[5]),
                    Highway = int.Parse(columns[6]),
                    Combined = int.Parse(columns[7])
                };
            }
        }
    }
}
