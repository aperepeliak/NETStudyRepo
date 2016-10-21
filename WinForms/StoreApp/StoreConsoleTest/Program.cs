using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StoreDataLayer.DbLayer;
using System.Data.Entity;

namespace StoreConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string n = "0f8fad5b-d9cb-469f-a165-70867728950e";

            string t = n.Substring(0, 23);

            Console.WriteLine(n);
            Console.WriteLine(t);


            Console.WriteLine("\n\nPress any key...");
            Console.ReadKey();
        }
    }
}
