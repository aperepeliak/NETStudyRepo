using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee
{
    class SalesPerson : Employee
    {
        public int SalesNumber { get; set; }


        public SalesPerson() { }

        public SalesPerson(string FullName, int age, int empID, float currPay, string ssn, int numbOfSales)
            : base (FullName, age, empID, currPay, ssn)
        {
            SalesNumber = numbOfSales;
        }
    }
}
