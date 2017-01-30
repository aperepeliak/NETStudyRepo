using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualMethods
{
    
    class Car
    {
        public virtual void ShowDetails()
        {
            Console.WriteLine("A car object");
        }
    }

    class ConvertibleCar : Car
    {
        public override void ShowDetails()
        {
            Console.WriteLine("Convertible Car");
        }
    }

    class ConvertibleCarDerive : ConvertibleCar
    {
        public virtual new void ShowDetails()
        {
            Console.WriteLine("ConvertibleDerive Car");
        }
    }

    class ConvertibleCarDeriveDerive : ConvertibleCarDerive
    {
        public override void ShowDetails()
        {
            Console.WriteLine("ConvertibleDeriveDerive Car");
        }
    }

    class Minivan : Car
    {
        public override void ShowDetails()
        {
            Console.WriteLine("Minivan Car");
        }
    }
}
