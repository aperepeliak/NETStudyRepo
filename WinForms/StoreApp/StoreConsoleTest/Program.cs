using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StoreDataLayer.DbLayer;
using System.Data.Entity;

namespace StoreConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            StoreContext context = new StoreContext();

            //context.Goods.Load();
            //List<Good> test = new List<Good>();
            //test = context.Goods.Local.ToList();
            //foreach (var g in test)
            //{
            //    Console.WriteLine($"{g.GoodName}, {g.Stock}");
            //}

            var test = context.UserProfiles.Include("Role").ToList();

            foreach (var item in test)
            {
                Console.WriteLine($"{item.UserLogin}, {item.Role.RoleName}");

            }


            Console.WriteLine("\n\nPress any key...");
            Console.ReadKey();
        }
    }
}
