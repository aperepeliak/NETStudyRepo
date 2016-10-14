using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;

using StoreManagement.DataLayer.DbLayer;


namespace StoreManagement.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            StoreContext context = new StoreContext();

            context.Roles.Load();

            List<Role> test = new List<Role>();

            test = context.Roles.ToList();

            foreach (var item in test)
            {
                Console.WriteLine(item.RoleName);
            }

            Console.WriteLine("End of test...");

        }
    }
}
