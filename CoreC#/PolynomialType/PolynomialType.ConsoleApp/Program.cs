using PolynomialType.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolynomialType.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Polinomial a = new Polinomial(new int[] { 20, -5, 1, 0, 0 });
            Polinomial b = new Polinomial(new int[] { 0, 0, 20, -5, 0, 1 });

            Console.WriteLine(b);

            Console.WriteLine("\n\nPress Enter to exit the program...");
            Console.ReadLine();
        }
    }
}
