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
                Polinomial a = new Polinomial(new int[] { 20, -5, 1, 10, 0 });
                Polinomial b = new Polinomial(4);

                var c = a + b;

                Console.WriteLine(c);
                //Console.WriteLine("************");
                //foreach (var i in c.Nums)
                //{
                //    Console.WriteLine(i);
                //}
            }
            catch (InvalidInputParamsForPolinomException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("\n\nPress Enter to exit the program...");
            Console.ReadLine();
        }
    }
}
