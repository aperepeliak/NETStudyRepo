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
                Polynomial b = new Polynomial(4);

                var c = a + b;

                Console.WriteLine(c);
                //Console.WriteLine("************");
                //foreach (var i in c.Nums)
                //{
                //    Console.WriteLine(i);
                //}
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
