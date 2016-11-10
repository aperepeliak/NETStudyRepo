using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructorChaining
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class Motorcycle
    {
        public int driverIntensity;
        public string driverName;

        // Constructor chaining
        public Motorcycle(int intensity)
            : this(intensity, "") { }

        public Motorcycle(string name)
            : this(0, name) { }

        // Master constructor
        public Motorcycle(int intensity, string name)
        {
            if (intensity > 10)
            {
                intensity = 10;
            }
            driverIntensity = intensity;
            driverName = name;
        }
    }
}
