using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;



namespace _001_MyTypeViewer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**** WELCOME TO MY TYPE VIEWER ****");

            string typeName = "";

            do
            {
                Console.Write("\n Enter a type name to evaluate -> ");

                typeName = Console.ReadLine();

                if (typeName == "Q")
                    break;

                try
                {
                    Type t = Type.GetType(typeName);
                    Console.WriteLine();
                    ListVariousStats(t);
                    ListFields(t);
                    ListProps(t);
                    ListMethods(t);
                    ListInterfaces(t);
                }
                catch
                {
                    Console.WriteLine("Sorry! Can't find type.");
                }

            } while (true);
        }

        static void ListMethods(Type t)
        {
            Console.WriteLine("==== Methods ====");

            // MethodInfo[] mi = t.GetMethods();

            // LINQ is more preferable
            var methodNames = t.GetMethods();

            foreach (var method in methodNames)
                Console.WriteLine($" -> {method}");

            Console.WriteLine();
        }

        static void ListFields(Type t)
        {
            Console.WriteLine("==== Fields ====");
            var fieldNames = t.GetFields().Select(f => f.Name);
            foreach (var n in fieldNames)
                Console.WriteLine($" -> {n}");

            Console.WriteLine();
        }

        static void ListProps(Type t)
        {
            Console.WriteLine("==== Props ====");
            var propNames = t.GetProperties().Select(p => p.Name);
            foreach (var n in propNames)
                Console.WriteLine($" -> {n}");

            Console.WriteLine();
        }

        static void ListInterfaces(Type t)
        {
            Console.WriteLine("==== Interfaces =====");
            var ifaces = t.GetInterfaces().Select(i => i.Name);
            foreach (var n in ifaces)
                Console.WriteLine($" -> {n}");

            Console.WriteLine();
        }

        static void ListVariousStats(Type t)
        {
            Console.WriteLine("==== Various Statistics ====");

            Console.WriteLine($"Base class is: {t.BaseType}");
            Console.WriteLine($"Is type abstract: {t.IsAbstract}");
            Console.WriteLine($"Is type sealed  : {t.IsSealed}");
            Console.WriteLine($"Is type generic : {t.IsGenericTypeDefinition}");
            Console.WriteLine($"Is type a class : {t.IsClass}");
            Console.WriteLine();
        }
    }
}
