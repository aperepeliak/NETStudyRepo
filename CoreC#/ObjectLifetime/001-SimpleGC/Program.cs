using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_SimpleGC
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**** GC Basics ****\n");

            // Estimated number of bytes on heap
            Console.WriteLine($"Estimated bytes on heap {GC.GetTotalMemory(false),10:N0}\n");

            Console.WriteLine($"This OS has {GC.MaxGeneration + 1} object generations.\n");

            var refToMyCar = new Car("Zippy", 50);
            Console.WriteLine($"Generation of refToMyCar is: {GC.GetGeneration(refToMyCar)}");

            // Only investigate generation 0 objects
            GC.Collect(0);
            GC.WaitForPendingFinalizers();
        }
    }
}
