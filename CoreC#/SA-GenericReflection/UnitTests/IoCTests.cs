using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SA_GenericReflection;

namespace UnitTests
{
    [TestClass]
    public class IoCTests
    {
        [TestMethod]
        public void Can_Resolve_Types()
        {
            var ioc = new Container(); 
            ioc.For<ILogger>().Use<SqlServerLogger>();

            var logger = ioc.Resolve<ILogger>();

            Assert.AreEqual(typeof(SqlServerLogger), logger.GetType());
        }

        [TestMethod]
        public void Can_Resolve_Types_Without_Default_Ctor()
        {
            var ioc = new Container();
            ioc.For<ILogger>().Use<SqlServerLogger>();
            ioc.For<IRepo<Employee>>().Use<SqlRepo<Employee>>();

            var repo = ioc.Resolve<IRepo<Employee>>();

            Assert.AreEqual(typeof(SqlRepo<Employee>), repo.GetType());
        }

        [TestMethod]
        public void Can_Resolve_Concrete_Type()
        {
            var ioc = new Container();
            ioc.For<ILogger>().Use<SqlServerLogger>();
            ioc.For(typeof(IRepo<>)).Use(typeof(SqlRepo<>));

            var service = ioc.Resolve<InvoiceService>();

            Assert.IsNotNull(service);
        }
    }
}
