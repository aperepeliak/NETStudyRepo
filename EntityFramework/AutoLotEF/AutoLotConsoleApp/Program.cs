using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoLotConsoleApp.EF;

namespace AutoLotConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintAllInventorySQL();
            Console.ReadLine();
        }

        private static void PrintAllInventory()
        {
            using (var context = new AutoLotEntities())
            {
                foreach (var c in context.Cars)
                {
                    Console.WriteLine(c);
                }
            }
        }

        private static void PrintAllInventorySQL()
        {
            using (var context = new AutoLotEntities())
            {
                foreach (Car c in context.Cars.SqlQuery("Select CarId,Make,Color,PetName as CarNickName from Inventory where Make=@p0", "BMW"))
                {
                    Console.WriteLine(c);
                }
            }
        }

        private static int AddNewRecord()
        {
            using (var context = new AutoLotEntities())
            {
                try
                {
                    var car = new Car() { Make = "Volvo", Color = "Grey", CarNickName = "Vova" };
                    context.Cars.Add(car);
                    context.SaveChanges();

                    return car.CarId;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }
    }
}
