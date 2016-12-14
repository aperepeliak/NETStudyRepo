using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _003_LateBindingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly a = null;

            try
            {
                a = Assembly.Load("CarLibrary");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            if (a != null)
                CreateUsingLateBinding(a);

            Console.ReadLine();
        }

        private static void CreateUsingLateBinding(Assembly asm)
        {
            try
            {
                // Get data for the miniVan type
                Type miniVan = asm.GetType("CarLibrary.MiniVan");

                // Create a miniVan instance on the fly
                object obj = Activator.CreateInstance(miniVan);
                Console.WriteLine($"Created a {obj} using late binding!");

                // Get info for TurboBoost
                MethodInfo mi = miniVan.GetMethod("TurboBoost");

                // Invoke method ('null' for null parameters)
                mi.Invoke(obj, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
