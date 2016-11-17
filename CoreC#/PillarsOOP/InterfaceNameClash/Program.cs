using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceNameClash
{
    class Program
    {
        static void Main(string[] args)
        {
            Octagon oct = new Octagon();

            // Draw() is not available through the dot operator because interfaces were implenented explicitly in the class
            // to access the required functionality must use explicit casting

            IDrawToForm toForm = (IDrawToForm)oct;
            toForm.Draw();

            // Shorthand notation if don't need to use the interface var later
            ((IDrawToMemory)oct).Draw();

            // Another option is to use the 'is' keyword
            if (oct is IDrawToPrinter)
                ((IDrawToPrinter)oct).Draw();
        }
    }

    class Octagon : IDrawToForm, IDrawToMemory, IDrawToPrinter
    {
        //public void Draw()
        //{
        //    Console.WriteLine("Shares draw method...");
        //}

        // No access modifiers!!
        // Explicitly implemented interfaces are automatically private.
        void IDrawToForm.Draw()
        {
            Console.WriteLine("Drawing to form...");
        }

        void IDrawToPrinter.Draw()
        {
            Console.WriteLine("Drawing to printer...");
        }

        void IDrawToMemory.Draw()
        {
            Console.WriteLine("Drawing to memory...");
        }
    }

    // Draw image to a form
    public interface IDrawToForm
    {
        void Draw();
    }

    // Draw to buffer in memory
    public interface IDrawToMemory
    {
        void Draw();
    }

    // Render to the printer
    public interface IDrawToPrinter
    {
        void Draw();
    }
}
