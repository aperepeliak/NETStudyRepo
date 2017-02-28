using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualityComparerExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var c1 = new Customer("Dow", "Joe");
            var c2 = new Customer("Dow", "Joe");

            var d = new Dictionary<Customer, string>(new LastFirstEqComparer());
            d[c1] = "Joe";
            Console.WriteLine(d.ContainsKey(c2));
        }
    }
}
