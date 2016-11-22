using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _003___CustomGenericMthod
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Custom generic methods\n\n");

            int a = 5, b = 99;

            Console.WriteLine($"Before swap: {a}\t{b}");
            MyGenericMethods.Swap<int>(ref a, ref b);
            Console.WriteLine($"After swap: {a}\t{b}");

            string s1 = "First", s2 = "Second";
            Console.WriteLine($"\nBefore swap: {s1}\t{s2}");
            MyGenericMethods.Swap<string>(ref s1, ref s2);
            Console.WriteLine($"After swap: {s1}\t{s2}");

            Console.WriteLine(new string('-', 20));
            MyGenericMethods.DisplayBaseClass<int>();
            MyGenericMethods.DisplayBaseClass<string>();
            MyGenericMethods.DisplayBaseClass<Type>();
            MyGenericMethods.DisplayBaseClass<ValueType>();
        }

       
    }
}
