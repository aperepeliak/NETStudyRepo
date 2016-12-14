using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;
using System.IO;

namespace _002_ExternalAssemblyReflector
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**** External Assembly Viewer ****\n");

            string asmName = "";
            Assembly asm = null;

            do
            {
                Console.Write("Enter an assembly to evaluate -> ");
                asmName = Console.ReadLine();

                if (asmName == "Q")
                    break;

                try
                {
                    asm = Assembly.Load(asmName);
                    DisplayTypesInAsm(asm);
                }
                catch
                {
                    Console.WriteLine("Sorry! Invalid invalid assembly name.");
                }
            } while (true);
        }

        static void DisplayTypesInAsm(Assembly asm)
        {
            Console.WriteLine("\n==== Types in Assembly ====");
            Console.WriteLine($" -> {asm.FullName}");

            Type[] types = asm.GetTypes();
            foreach (var t in types)
                Console.WriteLine($"Type: {t}");

            Console.WriteLine();
        }
    }
}
