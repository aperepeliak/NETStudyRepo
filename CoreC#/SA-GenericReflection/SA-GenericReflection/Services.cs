using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA_GenericReflection
{
    public interface ILogger
    {
        
    }

    public class SqlServerLogger : ILogger
    {

    }

    public interface IRepo<T>
    {

    }

    public class SqlRepo<T> : IRepo<T>
    {
        public SqlRepo(ILogger logger)
        {

        }
    }

    public class Customer
    {

    }

    public class InvoiceService
    {
        public InvoiceService(IRepo<Customer> repo, ILogger logger)
        {

        }
    }
}
