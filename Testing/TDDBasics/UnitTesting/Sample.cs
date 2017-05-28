using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

namespace UnitTesting
{
    public class MyClass
    {

    }

    public class Sample
    {
        public int Add(int x, int y)
        {
            return x + y;
        }

        public bool IsTesting()
        {
            return true;
        }
    }

    [TestFixture]
    public class SampleTests
    {
        private Sample s;

        [SetUp]
        public void SetUp()
        {
            s = new Sample();
        }


        [TestCase(1, 1)]
        [TestCase(-1, -1)]
        [TestCase(1, -1)]
        [TestCase(-1, 1)]
        public void AddReturnsSumOfBothParams(int a, int b)
        {
            int result = s.Add(a, b);

            int expected = a + b;

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void IsTestingReturnsTrue()
        {
            Assert.IsTrue(s.IsTesting());
        }
    }
}
