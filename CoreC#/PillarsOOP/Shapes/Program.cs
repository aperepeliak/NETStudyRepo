using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fun with polymorphism");

            Shape[] myShapes = { new Hexagon(),
                new Circle(),
                new Hexagon("vasya"),
                new Circle("dima"),
                new ThreeDCircle() };
            foreach (var shape in myShapes)
            {
                shape.Draw();
            }

            ThreeDCircle c = new ThreeDCircle();
            c.Draw();
        }
    }
}
