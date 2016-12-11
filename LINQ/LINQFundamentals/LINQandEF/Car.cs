using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQandEF
{
    public class Car
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public string Manufacturer { get; set; }
        public string Name { get; set; }
        public double Displacement { get; set; }
        public int Cylinders { get; set; }
        public int City { get; set; }
        public int Highway { get; set; }
        public int Combined { get; set; }

        public override string ToString()
        {
            return string.Format($"{Manufacturer, -30} {Name, -50} {Displacement, -5} {Cylinders,-4} {City, -4} {Highway, -4} {Combined, -4}");
        }
    }
}
