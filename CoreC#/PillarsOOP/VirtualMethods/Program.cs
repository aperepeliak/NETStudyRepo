using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car2 = new Minivan();
            Car car1 = new ConvertibleCar();
            Car car3 = new ConvertibleCarDerive();
            Car car4 = new ConvertibleCarDeriveDerive();

            car2.ShowDetails();
            car1.ShowDetails();
            car3.ShowDetails();
            car4.ShowDetails();
        }
    }
}
