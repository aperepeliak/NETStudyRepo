using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StoreDataLayer.DbLayer;
using System.Data.Entity;
using StoreDataLayer.BusinessLayer;

namespace StoreConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            StoreContext context = new StoreContext();

            context.SalePos.Load();

            var test = DisplaySalePos.GetSalePos(context, 5);

            foreach (var item in test)
            {
                Console.WriteLine($"{item.GoodName} {item.Quantity} {item.TotalSum}");
            }

            Console.ReadKey();
        }
    }
}
