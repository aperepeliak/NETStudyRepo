using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001___SimpleDelegate
{
    // This delegate can point to any method,
    // taking two int and returning an int
    public delegate int BinaryOp(int x, int y);

    // Class contains methods BinaryOp will point to
    public class SimpleMath
    {
        public static int Add(int x, int y) { return x + y; }
        public static int Subtract(int x, int y) { return x - y; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Simple delegate example\n");

            // delegate object that "points to" SimpleMath.Add() 
            BinaryOp b = new BinaryOp(SimpleMath.Add);

            // invoke Add() indirectly using delegate object
            Console.WriteLine($"10 + 10 is {b(10, 10)}");

            Console.WriteLine(new string('-', 20));

            DisplayDelegateInfo(b);
        }

        static void DisplayDelegateInfo(Delegate delObj)
        {
            foreach (Delegate d in delObj.GetInvocationList())
            {
                Console.WriteLine($"Method name: {d.Method}");
                Console.WriteLine($"Type name: {d.Target}");
            }
        }
    }
}
