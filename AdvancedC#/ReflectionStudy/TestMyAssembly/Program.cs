using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace TestMyAssembly
{
    class Program
    {
        static Assembly assembly = null;

        static void Main(string[] args)
        {
            // Loading the assembly
            try
            {
                assembly = Assembly.Load("MyAssembly");
                Console.WriteLine("Сборка MyAssembly - успешно загружена.");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }

            GetTriangleData(4.5, 6, 10);

        }

        private static void GetTriangleData(double a, double b, double c)
        {
            Type Triangle = assembly.GetType("MyAssembly.Triangle");
            object instanceTriangle = Activator.CreateInstance(Triangle);

            PropertyInfo A = Triangle.GetProperty("A");
            PropertyInfo B = Triangle.GetProperty("B");
            PropertyInfo C = Triangle.GetProperty("C");
            A.SetValue(instanceTriangle, a);
            B.SetValue(instanceTriangle, b);
            C.SetValue(instanceTriangle, c);

            MethodInfo Display = Triangle.GetMethod("Display");
            Display.Invoke(instanceTriangle, null);
        }

        private static void GetSquareData(double a)
        {
            Type Square = assembly.GetType("MyAssembly.Square");

        }

        private static void GetCircleData(double r)
        {
            Type Circle = assembly.GetType("MyAssembly.Circle");

        }
    }
}
