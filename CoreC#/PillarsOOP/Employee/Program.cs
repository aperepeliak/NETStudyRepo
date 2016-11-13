using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Learning Inheritance");
            Manager chucky = new Manager("Chucky", 50, 92, 1000, "332-22-323", 90000);
            double cost = chucky.GetBenefitCost();

            object dima = new Manager("Dima", 21, 22, 2000, "111-11-11", 10);

            GivePromotion((Manager)dima);
        }

        static void GivePromotion(Employee emp)
        {
            Console.WriteLine($"{emp.Name} was promoted!");
        }
    }
}
