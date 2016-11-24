using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _004___GenericDelegate
{
    // this generic delegate can represent any method returning void 
    // and taking a single parameter of type T
    public delegate void MyGenericDelegate<T>(T arg);

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Generic Delegates");

            // Register targets
            MyGenericDelegate<string> strTarget = new MyGenericDelegate<string>(StringTarget);
            strTarget("Some string data");

            MyGenericDelegate<int> intTarget = new MyGenericDelegate<int>(IntTarget);
            intTarget(9);
        }

        private static void IntTarget(int arg)
        {
            Console.WriteLine($"++arg is: {++arg}");
        }

        private static void StringTarget(string arg)
        {
            Console.WriteLine($"arg in upper-case is: {arg.ToUpper()}");
        }
    }
}
