using _001_ClassesObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades.Tests.Types
{
    [TestClass]
    public class TypeTests
    {

        [TestMethod]
        public void ValueTypesPassedByValue()
        {
            int x = 46;
            Increment(x);

            Assert.AreEqual(46, x);
        }

        private void Increment(int n)
        {
            n += 1;
        }

        [TestMethod]
        public void RefTypesPassByValue()
        {
            GradeBook b1 = new GradeBook();
            GradeBook b2 = b1;

            GiveBookAName(b2);

            Assert.AreEqual("A gradeBook", b1.Name);
        }

        private void GiveBookAName(GradeBook book)
        {
            book.Name = "A gradeBook";
        }

        [TestMethod]
        public void StringComparisons()
        {
            string name1 = "Andrew";
            string name2 = "andrew";

            bool result = String.Equals(name1, name2, StringComparison.InvariantCultureIgnoreCase);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IntVarsHoldAValue()
        {
            int x1 = 100;
            int x2 = x1;

            x1 = 4;

            Assert.AreNotEqual(x1, x2);
        }


        [TestMethod]
        public void GradeBookVarsHoldReference()
        {
            GradeBook g1 = new GradeBook();
            GradeBook g2 = g1;

            g1 = new GradeBook();
            g1.Name = "My grade book";

            Assert.AreNotEqual(g1.Name, g2.Name);
        }
    }
}
