using PolynomialType.Model;
using PolynomialType.Model.CustomExceptions;
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
            try
            {
                Polynomial a = new Polynomial(new int[] { 20, -5, 1, 10, 0 });
                Polynomial b = new Polynomial(5, 5);
                Polynomial c = new Polynomial(new int[] { 2, 4 });

                var d = a * c * b;

                Console.WriteLine(d);
            }
            catch (InvalidInputParamsForPolynomException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("\n\nPress Enter to exit the program...");
            Console.ReadLine();
        }
    }
}
