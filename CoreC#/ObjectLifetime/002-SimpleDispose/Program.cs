using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002_SimpleDispose
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**** Fun with dispose ****");

            // Dispose() is called automatically when the using scope exits
            using (MyResourceWrapper rw = new MyResourceWrapper(),
                                     rw2 = new MyResourceWrapper())
            {
                // rw object usage
            }

            Console.ReadLine();
        }
    }
}
