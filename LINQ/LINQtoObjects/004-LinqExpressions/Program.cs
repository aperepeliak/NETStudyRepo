using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _004_LinqExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**** Query Expressions ****\n");

            ProductInfo[] itemsInStock = new[]
            {
                new ProductInfo {Name = "Smartphone", Description = "It is a nice smartphone", NumberInStock = 24 },
                new ProductInfo {Name = "Laptop", Description = "Dell XPS L502", NumberInStock = 100 },
                new ProductInfo {Name = "Printer", Description = "HP Photosmart (BROKEN)", NumberInStock = 5 },
                new ProductInfo {Name = "Headphones", Description = "for iPhone", NumberInStock = 200 },
                new ProductInfo {Name = "Memory bank", Description = "not to forget anything", NumberInStock = 50 },
                new ProductInfo {Name = "Scanner", Description = "I can see you inside out", NumberInStock = 5 }
            };

            // SelectEverything(itemsInStock);
            // ListProductNames(itemsInStock);
            // GetOverstock(itemsInStock);
            // GetNamesAndDescs(itemsInStock);

            //Array objs = GetProjectedSubset(itemsInStock);
            //foreach(var o in objs)
            //    Console.WriteLine(o);

            // GetCountFromQuery();

            // ReverseEverything(itemsInStock);

            // Alphabetize(itemsInStock);

            // DisplayDiff();

            // DisplayIntersection();

            // DisplayUnion();

            // DisplayConcat();

            // DisplayConcatNoDups();

            AggregateOps();
        }

        static void SelectEverything(ProductInfo[] products)
        {
            Console.WriteLine("All product details:");
            var allProducts = from p in products
                              select p;

            foreach (var prod in allProducts)
                Console.WriteLine(prod.ToString());
        }

        static void ListProductNames(ProductInfo[] products)
        {
            Console.WriteLine("Only product names: ");
            var names = from p in products
                        select p.Name;

            foreach (var n in names)
                Console.WriteLine($"Name: {n}");
        }

        static void GetOverstock(ProductInfo[] products)
        {
            Console.WriteLine("The overstock items: ");

            var overstock = from p in products
                            where p.NumberInStock > 25
                            select p;

            foreach (var p in overstock)
                Console.WriteLine($"Name: {p.ToString()}");
        }

        static void GetNamesAndDescs(ProductInfo[] products)
        {
            Console.WriteLine("Names and descriptions: ");

            var nameDesc = from p in products
                           select new { p.Name, p.Description };

            foreach (var i in nameDesc)
                Console.WriteLine(i.ToString());
        }

        static Array GetProjectedSubset(ProductInfo[] products)
        {
            var nameDesc = from p in products
                           select new { p.Name, p.Description };

            // Map set of anonymous objects to an Array object
            return nameDesc.ToArray();
        }

        static void GetCountFromQuery()
        {
            string[] books = { "ASP.NET MVC", "CLR via C#", ".NET Framework 4.6", "Entity Framework 6" };

            // Get count from the query
            int num = (from b in books
                       where b.Length > 15
                       select b).Count();

            Console.WriteLine($"{num} items have more than 15 letters");
        }

        static void ReverseEverything(ProductInfo[] products)
        {
            Console.WriteLine("Products in reverse: ");
            var allProductsReverse = (from p in products
                                      select p).Reverse();

            foreach (var p in allProductsReverse)
                Console.WriteLine(p.ToString());
        }

        static void Alphabetize(ProductInfo[] products)
        {
            Console.WriteLine("Products in alphabetical order (by name): ");
            var subset = from p in products
                         orderby p.Name ascending
                         select p;

            foreach (var p in subset)
                Console.WriteLine(p.ToString());
        }

        static void DisplayDiff()
        {
            List<string> myCars = new List<string>() { "Fiat", "VAZ", "ZAZ" };
            List<string> yourCars = new List<string>() { "VAZ", "ZAZ", "Bentley" };

            // Save what is not in the second list
            var carDiff = (from c in myCars
                           select c)
                          .Except(from c in yourCars
                                  select c);

            Console.WriteLine("Here is what you don't have, but I do: ");
            foreach (var c in carDiff)
                Console.WriteLine(c);
        }

        static void DisplayIntersection()
        {
            List<string> myCars = new List<string>() { "Fiat", "VAZ", "ZAZ" };
            List<string> yourCars = new List<string>() { "VAZ", "ZAZ", "Bentley" };

            var carIntersect = (from c in myCars
                                select c)
                                .Intersect(from c in yourCars
                                           select c);

            Console.WriteLine("Here is what we have in common: ");
            foreach (var c in carIntersect)
                Console.WriteLine(c);
        }

        static void DisplayUnion()
        {
            List<string> myCars = new List<string>() { "Fiat", "VAZ", "ZAZ" };
            List<string> yourCars = new List<string>() { "VAZ", "ZAZ", "Bentley" };

            var carUnion = (from c in myCars
                            select c)
                            .Union(from c in yourCars
                                   select c);

            Console.WriteLine("Here is everything: ");
            foreach (var c in carUnion)
                Console.WriteLine(c);
        }

        static void DisplayConcat()
        {
            List<string> myCars = new List<string>() { "Fiat", "VAZ", "ZAZ" };
            List<string> yourCars = new List<string>() { "VAZ", "ZAZ", "Bentley" };

            var carConcat = (from c in myCars
                             select c)
                             .Concat(from c in yourCars
                                     select c);

            Console.WriteLine("Two lists concatenated: ");
            foreach (var c in carConcat)
                Console.WriteLine(c);
        }

        static void DisplayConcatNoDups()
        {
            List<string> myCars = new List<string>() { "Fiat", "VAZ", "ZAZ" };
            List<string> yourCars = new List<string>() { "VAZ", "ZAZ", "Bentley" };

            var carConcat = ((from c in myCars
                              select c)
                             .Concat(from c in yourCars
                                     select c))
                                     .Distinct();

            Console.WriteLine("Concat with no duplicates: ");
            foreach (var c in carConcat)
                Console.WriteLine(c);
        }

        static void AggregateOps()
        {
            double[] winterTemps = { 2.0, -21.3, 8, 4, 0, -9 };

            Console.WriteLine($"Max temp : {(from t in winterTemps select t).Max()}\n");
            Console.WriteLine($"Min temp : {(from t in winterTemps select t).Min()}\n");
            Console.WriteLine("Average  : {0:f2}\n",
                (from t in winterTemps select t).Average());
            Console.WriteLine($"Sum of t : {(from t in winterTemps select t).Sum()}\n");
            Console.WriteLine($"Count ts : {(from t in winterTemps select t).Count()}\n");
        }
    }
}
