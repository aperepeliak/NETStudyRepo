using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee
{
    class Manager : Employee
    {
        public int StockOptions { get; set; }

        public Manager() { }

        public Manager(string FullName, int age, int empID, float currPay, string ssn, int numbOfOpts)
            : base(FullName, age, empID, currPay, ssn)
        {
            StockOptions = numbOfOpts;
        }
    }
}
