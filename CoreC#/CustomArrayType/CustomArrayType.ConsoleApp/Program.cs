using CustomArrayType.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomArrayType.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomArray<string> test = new CustomArray<string>(5, -1);

            test[1] = "hello";
            test[2] = "world";
            test[3] = null;

            foreach (var item in test)
            {
                Console.WriteLine(item ?? "null");
            }
        }
    }
}
