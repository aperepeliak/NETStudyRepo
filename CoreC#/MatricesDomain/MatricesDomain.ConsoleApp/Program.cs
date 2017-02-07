using MatricesDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatricesDomain.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {


            var a = new Matrix(new int[,] { { 1, 2, 3 }, { 4, 5, 6 } });
            var b = new Matrix(new int[,] { { 10, 10 }, { 10, 10 }, { 10, 10 } });

            var c = a * b;

            Console.WriteLine(c);
        }
    }
}
