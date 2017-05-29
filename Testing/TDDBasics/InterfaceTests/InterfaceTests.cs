using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

namespace InterfaceTests
{
    [TestFixture]
    public class InterfaceTests
    {
        [Test]
        public void DanImplementsIPerson()
        {
            var dan = new Dan();
            var helper = new Helper();

            var result = helper.Greet(dan);

            Assert.That(result, Is.EqualTo("Hi there"));
        }

        [Test]
        public void LizImplementsIPerson()
        {
            var liz = new Liz();
            var helper = new Helper();

            var result = helper.Greet(liz);

            Assert.That(result, Is.EqualTo("Howdy!"));
        }

        [Test]
        public void DanHasAnAge()
        {
            var dan = new Dan() { Age = 35 };
            var helper = new Helper();

            var result = helper.GetAge(dan);

            Assert.That(result, Is.EqualTo(35));
        }

        [Test]
        public void LizHasAnAge()
        {
            var liz = new Dan() { Age = 25 };
            var helper = new Helper();

            var result = helper.GetAge(liz);

            Assert.That(result, Is.EqualTo(25));
        }
    }

    public interface IPerson
    {
        int Age { get; set; }
        string SayHello();
    }

    public class Dan : IPerson
    {
        public int Age { get; set; }

        public string SayHello()
        {
            return "Hi there";
        }
    }

    public class Liz : IPerson
    {
        public int Age { get; set; }

        public string SayHello()
        {
            return "Howdy!";
        }
    }

    public class Helper
    {
        public string Greet(IPerson p)
        {
            return p.SayHello();
        }

        public int GetAge(IPerson p)
        {
            return p.Age;
        }
    }
}
