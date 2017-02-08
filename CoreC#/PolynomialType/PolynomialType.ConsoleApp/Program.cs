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
                Polinomial a = new Polinomial(new int[] { 20, -5, 1, 0, 0 });
                Polinomial b = new Polinomial(new int[] { 0, 0, 1, 0, 5, 6, 0, 0, 0 });

                Console.WriteLine(b);
                Console.WriteLine("************");
                foreach (var i in b.Nums)
                {
                    Console.WriteLine(i);
                }
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
