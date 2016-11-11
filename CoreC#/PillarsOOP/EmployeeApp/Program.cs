using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Learning Encapsulation\n");
            Employee emp = new Employee("Marvin", 25, 456, 30000);
            emp.GiveBonus(1000);
            emp.DisplayStats();

            emp.Name = "Marv";
            Console.WriteLine($"Employee is named: {emp.Name}");
            Console.ReadKey();
        }
    }
}
