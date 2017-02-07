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
                var b = new Matrix();

                var d = a * b;

                a.SaveToXml("Matrix.xml");
                var c = new Matrix(Matrix.LoadFromXml("Matrix.xml"));
                Console.WriteLine(b);
            }
            catch (InvalidMatricesSizesException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.HelpLink);
            }
            catch (InvalidMultiplicationException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.HelpLink);
            }
            catch (InvalidSizeParameterException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.HelpLink);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("The given filename is invalid.");
                Console.WriteLine($"Details: {ex.Message}");
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("***NullReferenceException***");
                Console.WriteLine($"Target\t  : {ex.TargetSite}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Message\t : {ex.Message}");
                Console.WriteLine($"Target\t  : {ex.TargetSite}");
            }

            Console.WriteLine("\n\nPress ENTER to exit the program.");
            Console.ReadLine();
        }
    }
}
