using System;
using EmailValidatorServiceClient.ServiceReference;

namespace EmailValidatorServiceClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Welcome to EmailValidator *****\n");

            using (var emailValidator = new EmailValidatorClient("NetTcpBinding_IEmailValidator"))
            {
                Console.Write("Enter e-mail address to validate -> ");
                string email = Console.ReadLine();

                bool response = emailValidator.ValidateAddress(email);

                var baseColor = Console.ForegroundColor;
                if (response)
                {
                    Console.Write("Result: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Valid");
                    Console.ForegroundColor = baseColor;
                }
                else
                {
                    Console.Write("Result: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid");
                    Console.ForegroundColor = baseColor;
                }
            }
            Console.WriteLine("\nPress ENTER to exit...");
            Console.ReadLine();
        }
    }
}
