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
