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
                Console.WriteLine("MyAssembly has been successfully loaded.");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }

            GetTriangleData(4.5, 6, 10);
            GetSquareData(5);
            GetCircleData(4);
        }

        private static void GetTriangleData(double a, double b, double c)
        {
            Type Triangle = assembly.GetType("MyAssembly.Triangle");
            object instance = Activator.CreateInstance(Triangle);

            PropertyInfo A = Triangle.GetProperty("A");
            PropertyInfo B = Triangle.GetProperty("B");
            PropertyInfo C = Triangle.GetProperty("C");
            A.SetValue(instance, a);
            B.SetValue(instance, b);
            C.SetValue(instance, c);

            MethodInfo Display = Triangle.GetMethod("Display");
            Display.Invoke(instance, null);
        }

        private static void GetSquareData(double a)
        {
            Type Square = assembly.GetType("MyAssembly.Square");
            object instance = Activator.CreateInstance(Square);

            PropertyInfo A = Square.GetProperty("A");
            A.SetValue(instance, a);

            MethodInfo Display = Square.GetMethod("Display");
            Display.Invoke(instance, null);
        }

        private static void GetCircleData(double r)
        {
            Type Circle = assembly.GetType("MyAssembly.Circle");
            object instance = Activator.CreateInstance(Circle);

            PropertyInfo R = Circle.GetProperty("R");
            R.SetValue(instance, r);

            MethodInfo Display = Circle.GetMethod("Display");
            Display.Invoke(instance, null);
        }
    }
}
