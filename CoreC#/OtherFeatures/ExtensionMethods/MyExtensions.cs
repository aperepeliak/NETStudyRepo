using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace MyExt
{
    static class MyExtensions
    {
        public static void DisplayDefiningAssembly(this object obj)
        {
            Console.WriteLine($"{obj.GetType().Name} lives here: => {Assembly.GetAssembly(obj.GetType()).GetName().Name}");
        }

        public static int ReverseDigits(this int i)
        {
            // 1) int => string => char[]
            char[] digits = i.ToString().ToCharArray();

            // 2) reversing
            Array.Reverse(digits);

            // 3) back to string
            string newDigits = new string(digits);

            // 4) bacl to int
            return int.Parse(newDigits);
        }
    }
}
