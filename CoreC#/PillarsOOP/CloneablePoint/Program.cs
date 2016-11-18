using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloneablePoint
{
    class Program
    {
        static void Main(string[] args)
        {
            // Two references to the same object
            Point p1 = new Point(1, 2);
            Point p2 = p1;

            // Because Clone() returns a  plain object type we must perform an explicit cast
            Point p3 = new Point(20, 14);
            Point p4 = (Point)p3.Clone();

            Console.WriteLine("Cloned p5 and stored new Point in p6\n");
            Point p5 = new Point(100, 100, "Jane");
            Point p6 = (Point)p5.Clone();

            Console.WriteLine("Before modification:");
            Console.WriteLine($"p5:\t{p5}");
            Console.WriteLine($"p6:\t{p6}");

            p6.desc.PetName = "My new Point";
            p6.X = 77;

            Console.WriteLine("After modification:");
            Console.WriteLine($"p5:\t{p5}");
            Console.WriteLine($"p6:\t{p6}");
        }
    }
}
