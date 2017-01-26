using ConsoleClientTestApp.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClientTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ContractClient client = new ContractClient("NetTcpBinding_IContract", "net.tcp://localhost:8081/Contract");

            var res = client.GetCategories();
        }
    }
}
