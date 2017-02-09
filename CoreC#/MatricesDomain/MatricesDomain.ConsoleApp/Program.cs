using MatricesDomain.Model;
using MatricesDomain.Model.CustomExceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatricesDomain.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var a = new Matrix(new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 1, 1, 1 } });
                var b = new Matrix(new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 1, 1, 1 } });
                var d = a * b - a;
                
                Console.WriteLine(d);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Message  : {ex.Message}");
                Console.WriteLine($"Target   : {ex.TargetSite}");
                Console.WriteLine($"Helplink : {ex.HelpLink}\n");
                Console.WriteLine("****************************************\n");
                Console.WriteLine($"Inner Exception: {ex.InnerException}");
            }

            Console.WriteLine("\n\nPress ENTER to exit the program.");
            Console.ReadLine();
        }
    }
}
