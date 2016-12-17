using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _002_DefaultAppDomainApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // DisplayDADStats();
            ListAllAssembliesInAppDomain();
        }

        private static void ListAllAssembliesInAppDomain()
        {
            // Get access to the AppDomain for the current thread
            AppDomain defaultAD = AppDomain.CurrentDomain;

            // Get all loaded assemblies in the default AppDomain
            Assembly[] loadedAssemblies = defaultAD.GetAssemblies();
            Console.WriteLine($"Here are assemblies loaded in {defaultAD.FriendlyName}");
            foreach (Assembly asm in loadedAssemblies)
            {
                Console.WriteLine($" -> Name: {asm.GetName().Name}");
                Console.WriteLine($" -> Version: {asm.GetName().Version}");
            }
        }

        private static void DisplayDADStats()
        {
            // Get access to the AppDomain for the current thread
            AppDomain defaultAD = AppDomain.CurrentDomain;

            // Stats about the domain
            Console.WriteLine($"Name of the domain: {defaultAD.FriendlyName}");
            Console.WriteLine($"ID of the domain in this process: {defaultAD.Id}");
            Console.WriteLine($"Is this the default domain : {defaultAD.IsDefaultAppDomain()}");
            Console.WriteLine($"Base directory of the domain: {defaultAD.BaseDirectory}");
        }
    }
}
