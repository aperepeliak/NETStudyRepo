using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicExapamples
{
    class Program
    {
        static void Main(string[] args)
        {
            // Using ?-suffixed notation
            int? a = 5;
            double? b = 3.14;
            bool? c = null;

            // Error. Strings are reference type
            // string? str = "oops";

            // Using Nullable<T> notation
            Nullable<int> aa = 5;
            Nullable<bool> bb = null;


            Console.WriteLine("Working with nullables");
            DatabaseReader dr = new DatabaseReader();

            int? i = dr.GetIntFromDatabase();

            // Usage of null coalescing operator
            int myData = dr.GetIntFromDatabase() ?? 100;

            if (i.HasValue)
            {
                Console.WriteLine($"Value of i is {i.Value}");
            }
            else
            {
                Console.WriteLine("Value of i is undefined");
            }

            bool? boo = dr.GetBoolFromDatabase();
            if (boo != null)
            {
                Console.WriteLine($"value of boo is {boo}");
            }
            else
            {
                Console.WriteLine("Value of boo is undefined");
            }

            Console.WriteLine("-----------------");
            TesterMethod(null);
        }

        public static void TesterMethod(string[] args)
        {
            // An expample of null conditional operator
            Console.WriteLine($"You sent me {args?.Length ?? 0} arguments.");
        }
    }

    class DatabaseReader
    {
        // Nullable data fields
        public int? numericValue = null;
        public bool? boolValue = true;

        public int? GetIntFromDatabase() { return numericValue; }
        public bool? GetBoolFromDatabase() { return boolValue; }
    }
}
