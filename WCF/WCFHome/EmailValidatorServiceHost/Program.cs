using System;
using System.ServiceModel;
using EmailValidatorServiceLib;

namespace EmailValidatorServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===== WCF EmailValidator Host =====");

            using (var serviceHost = new ServiceHost(typeof(EmailValidatorService)))
            {
                serviceHost.Open();
                Console.WriteLine("\nThe service is ready.\n");
                Console.WriteLine("Press ENTER to terminate the service.");
                Console.ReadLine();
            }
        }
    }
}
