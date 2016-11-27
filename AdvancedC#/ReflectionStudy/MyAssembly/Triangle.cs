using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAssembly
{
    public class Triangle : Figure, IFigure
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }

        public double Area()
        {
            double p = Perimeter() / 2;
            return (Math.Sqrt(p * (p - A) * (p - B) * (p - C)));
        }

        public double Perimeter()
        {
            return (A + B + C);
        }

        public void Display()
        {
            Console.WriteLine("\t=> Displaying TRIANGLE");
        }

        public override void Draw()
        {
            Console.WriteLine("\t=> Drawing TRIANGLE");
        }
    }
}
