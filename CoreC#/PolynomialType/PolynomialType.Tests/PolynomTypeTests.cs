using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolynomialType.Model;

namespace PolynomialType.Tests
{
    [TestClass]
    public class PolynomTypeTests
    {
        [TestMethod]
        public void ReturnsCorrectString()
        {
            Polinomial b = new Polinomial(new int[] { 20, -5, 1, 0, 1 });

            string expect = "20x^4 + -5x^3 + x^2 + 1";

            Assert.AreEqual(expect, b.ToString());
        }
    }
}
