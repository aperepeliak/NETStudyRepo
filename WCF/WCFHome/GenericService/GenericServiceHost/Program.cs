using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ServiceModel;
using GenericServiceLib;
using GenericServiceLib.Repos;

namespace GenericServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Service Host";

            using (var host = new ServiceHost(typeof(Contract)))
            {
                host.Open();

                Console.WriteLine("The host is running ...\n\n\n");

                Console.WriteLine("Press ENTER to exit");
                Console.ReadLine();
            }
        }
    }
}
