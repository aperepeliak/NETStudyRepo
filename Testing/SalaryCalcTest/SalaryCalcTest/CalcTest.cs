using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalaryCalcTest;

namespace SalaryCalcTest
{
    [TestClass]
    public class CalcTest
    {
        [TestMethod]
        public void AnnualSalaryTest()
        {
            // Arrange
            SalaryCalculator sc = new SalaryCalculator();

            // Act
            decimal annualSalary = sc.GetAnnualSalaryMethod(50);

            // Assert
            Assert.AreEqual(104000, annualSalary);
        }

        [TestMethod]
        public void HourlyWageTest()
        {
            SalaryCalculator sc = new SalaryCalculator();

            decimal hourlyWage = sc.GetHourlyWage(52000);

            Assert.AreEqual(25, hourlyWage);
        }
    }
}
