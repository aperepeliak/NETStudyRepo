using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _006___JoeShipping
{
    class Program
    {
        static void Main(string[] args)
        {
            ShippingFeesDelegate feeDelegate;
            ShippingDestination destination;
            string zone;

            do
            {
                Console.Write("Enter the destination -> ");
                zone = Console.ReadLine();

                if (zone != "exit")
                {
                    destination = ShippingDestination.getDestinationInfo(zone);

                    if (destination != null)
                    {
                        Console.Write("   > Enter item price -> ");
                        string priceStr = Console.ReadLine();
                        decimal price = decimal.Parse(priceStr);

                        feeDelegate = destination.calcFees;

                        decimal finalFee = 0.0m;
                        feeDelegate(price, ref finalFee);
                        Console.WriteLine($"   > The shipping fee is: {finalFee}\n");
                    }
                    else
                    {
                        Console.WriteLine("   > Unknown destination. Try again or type 'exit'");
                    }
                }
            } while (zone != "exit");
        }
    }
}
