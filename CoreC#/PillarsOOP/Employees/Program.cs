using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Employee class hierarchy");

            SalesPerson fred = new SalesPerson();
            fred.Age = 34;
            fred.Name = "Fred";
            fred.SalesNumber = 50;
        }
    }
}
