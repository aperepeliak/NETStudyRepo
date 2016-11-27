using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAssembly
{
    public class Square : Figure, IFigure
    {
        public double A { get; set; }

        public double Area()
        {
            return A * A;
        }

        public double Perimeter()
        {
            return 4 * A;
        }

        public void Display()
        {
            Console.WriteLine("\t=> Displaying SQUARE");
        }

        public override void Draw()
        {
            Console.WriteLine("\t=> Drawing SQUARE");
        }
    }
}
