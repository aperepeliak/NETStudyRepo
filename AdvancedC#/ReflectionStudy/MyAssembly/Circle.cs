using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAssembly
{
    public class Circle : Figure, IFigure
    {
        public double R { get; set; }

        public double Area()
        {
            return (Math.PI * R * R);
        }

        public double Perimeter()
        {
            return (2 * Math.PI * R);
        }

        public void Display()
        {
            Console.WriteLine("\t=> Displaying CIRCLE");
        }

        public override void Draw()
        {
            Console.WriteLine("\t=> Drawing CIRCLE");
        }
    }
}
