using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleInheritance
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    interface IDrawable
    {
        void Draw();
    }

    interface IPrintable
    {
        void Print();
        void Draw(); // <-- Possible name clash
    }

    interface IShape : IDrawable, IPrintable
    {
        int GetNumberOfSides();
    }

    // Simple implicit implementation of the interface
    class Rectangle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Drawing ...");
        }

        public int GetNumberOfSides()
        {
            return 4;
        }

        public void Print()
        {
            Console.WriteLine("Printing ...");
        }
    }

    class Square : IShape
    {
        void IPrintable.Draw()
        {
            Console.WriteLine("Drawing to printer ...");
        }

        void IDrawable.Draw()
        {
            Console.WriteLine("Drawing to screen ...");
        }

        int IShape.GetNumberOfSides()
        {
            return 4;
        }

        void IPrintable.Print()
        {
            Console.WriteLine("Printing ...");
        }
    }
}
