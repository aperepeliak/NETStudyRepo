using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MatricesDomain.Model;

namespace MatricesDomain.Tests
{
    [TestClass]
    public class MatricesTest
    {

        [TestMethod]
        public void CreatesDefaultMatrix()
        {
            var test = new Matrix(3);

            Assert.AreEqual(test[0, 0], 0);
            Assert.AreEqual(test.NumColumns, test.NumRows);
            Assert.AreEqual(test.NumColumns, 3);
        }

        [TestMethod]
        public void CreatesMatrixWithInputArray()
        {
            int[,] arr = new int[,] { { 1, 2, 3 }, { 4, 5, 6 } };
            var m = new Matrix(arr);

            Assert.AreEqual(arr[1, 1], m[1, 1]);
            Assert.AreEqual(arr.GetLength(0), m.NumRows);
        }

        [TestMethod]
        public void ReturnsOverridenToString()
        {
            var m = new Matrix(new int[,] { { 1, 2, 3 }, { 4, 5, 6 } });
            string expect = "1\t2\t3\t\n4\t5\t6\t\n";
            string res = m.ToString();

            Assert.AreEqual(res, expect);
        }

        [TestMethod]
        public void SumsMatrices()
        {
            int[,] arr = new int[,] { { 1, 2, 3 }, { 4, 5, 6 } };
            var a = new Matrix(arr);
            var b = new Matrix(arr);

            var c = a + b;
            var expect = new Matrix(new int[,] { { 2, 4, 6 }, { 8, 10, 12 } });

            Assert.AreEqual(expect, c);
        }

        [TestMethod]
        public void SumsMatrixAndNumber()
        {
            var m = new Matrix(new int[,] { { 1, 2, 3 }, { 4, 5, 6 } });
            Matrix res = m + 5;
            var expect = new Matrix(new int[,] { { 6, 7, 8 }, { 9, 10, 11 } });

            Assert.AreEqual(res, expect);
        }

        [TestMethod]
        public void SubtractsMatrices()
        {
            int[,] arr = new int[,] { { 1, 2, 3 }, { 4, 5, 6 } };
            var a = new Matrix(arr);
            var b = new Matrix(arr);

            var c = a - b;
            var expect = new Matrix(new int[,] { { 0, 0, 0 }, { 0, 0, 0 } });

            Assert.AreEqual(expect, c);
        }

        [TestMethod]
        public void SubtractsatrixAndNumber()
        {
            var m = new Matrix(new int[,] { { 1, 2, 3 }, { 4, 5, 6 } });
            Matrix res = m - 1;
            var expect = new Matrix(new int[,] { { 0, 1, 2 }, { 3, 4, 5 } });

            Assert.AreEqual(res, expect);
        }
    }
}
