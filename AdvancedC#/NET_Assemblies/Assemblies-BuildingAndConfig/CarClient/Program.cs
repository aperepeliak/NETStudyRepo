using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CarLibrary;

namespace CarClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**** CarLibrary Client App ****");

            SportsCar viper = new SportsCar("Viper", 240, 40);
            var mv = new MiniVan();
            mv.TurboBoost();

            Console.WriteLine("Press any key to terminate.");
        }
    }
}
