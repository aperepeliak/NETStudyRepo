using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using Moq;

namespace MoqTests
{
    [TestFixture]
    public class MoqTests
    {
        private MockRepository _mockRepo;
        private Mock<IPerson> _person;

        [SetUp]
        public void SetUp()
        {
            _mockRepo = new MockRepository(MockBehavior.Strict);
            _person = _mockRepo.Create<IPerson>(); 
        }

        [TearDown]
        public void TearDown()
        {
            _mockRepo.VerifyAll();
        }

        [Test]
        public void MockReturnsSayHelloValue()
        {
            _person.Setup(p => p.SayHello()).Returns("Yo!");

            var helper = new Helper();
            var result = helper.Greet(_person.Object);

            Assert.That(result, Is.EqualTo("Yo!"));
        }
    }

    public interface IPerson
    {
        int Age { get; set; }
        string SayHello();
    }

    public class Helper
    {
        public string Greet(IPerson p)
        {
            return p.SayHello();
        }
    }
}
