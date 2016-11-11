using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoProps
{
    class Garage
    {
        // The hidden backing field is set to 1
        public int NumOfCars { get; set; } = 1;

        // The Hidden backing field  is set to a new Car object
        public Car MyAuto { get; set; } = new Car();

        public Garage() { }
        public Garage(Car car, int number)
        {
            MyAuto = car;
            NumOfCars = number;
        }
    }
}
