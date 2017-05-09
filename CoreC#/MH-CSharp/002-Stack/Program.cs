using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002_Stack
{

    class Program
    {
        static void Main(string[] args)
        {
            var stack = new Stack();

            stack.Push(1);
            stack.Push(2);

            stack.Clear();
            stack.Push(4);

            Console.WriteLine(stack.Pop());
        }
    }
}
