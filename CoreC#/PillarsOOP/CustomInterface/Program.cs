using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            Shape[] myShapes = { new Hexagon(),
                new Circle(),
                new Triangle("Joe"),
                new ThreeDCircle() };

            foreach (var shape in myShapes)
            {
                shape.Draw();
                if (shape is IDraw3D)
                    DrawIn3D((IDraw3D)shape);
            }

            IPointy firstPointyItem = FindFirstPointyShape(myShapes);
            if (firstPointyItem != null)
                Console.WriteLine($"\n\nThe first Pointy item is: {firstPointyItem} and has {firstPointyItem.Points} points");
        }

        static void DrawIn3D(IDraw3D drawMe)
        {
            Console.WriteLine(" -> Drawing IDraw3D compatible type");
            drawMe.Draw3D();
        }

        static IPointy FindFirstPointyShape(Shape[] shapes)
        {
            foreach (var shape in shapes)
            {
                if (shape is IPointy)
                    return shape as IPointy;
            }
            return null;
        }
    }
}
