using System;

namespace SalaryCalcTest
{
    public class SalaryCalculator
    {
        const int HOURS_IN_YEAR = 2080;

        public SalaryCalculator() { }

        public decimal GetAnnualSalaryMethod(decimal hourlyWage) => HOURS_IN_YEAR * hourlyWage;
        public decimal GetHourlyWage(int annualSalary) => annualSalary / HOURS_IN_YEAR;
    }
}