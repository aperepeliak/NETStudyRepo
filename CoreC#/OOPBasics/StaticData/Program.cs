using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticData
{
    class Program
    {
        static void Main(string[] args)
        {
            StaticClass.PrintTime();
            StaticClass.PrintDate();
        }
    }

    class SavingsAccount
    {
        // Instance-level data
        public double currBalance;

        public static double currInterestRate;

        public SavingsAccount(double balance)
        {
            currBalance = balance;
        }

        static SavingsAccount()
        {
            Console.WriteLine("Static ctor!");
            currInterestRate = 0.04;
        }

        public static void SetInterestRate(double newRate)
        {
            currInterestRate = newRate;
        }

        public static double GetInterestRate()
        {
            return currInterestRate;
        }
    }
}
