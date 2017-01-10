using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ServiceModel;
using MagicEightBallServiceLib;
using System.ServiceModel.Description;

namespace MagicEightBallServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**** Console based WCF Host ****");

            using (var serviceHost = new ServiceHost(typeof(MagicEightBallService)))
            {
                serviceHost.Open();

                DisplayHostInfo(serviceHost);

                Console.WriteLine("\nThe service is ready.\n");
                Console.WriteLine("Press ENTER to terminate the service.");
                Console.ReadLine();
            }
        }

        static void DisplayHostInfo(ServiceHost host)
        {
            Console.WriteLine("\n==== Host Info ====");
            foreach (ServiceEndpoint se in host.Description.Endpoints)
            {
                Console.WriteLine($"Address: {se.Address}");
                Console.WriteLine($"Binding: {se.Binding.Name}");
                Console.WriteLine($"Contract: {se.Contract.Name}");
            }
            Console.WriteLine("===================");
        }
    }
}
