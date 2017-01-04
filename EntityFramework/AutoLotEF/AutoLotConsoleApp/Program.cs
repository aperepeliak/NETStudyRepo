using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoLotConsoleApp.EF;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace AutoLotConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            UpdateRecord(15);

            Console.ReadLine();
        }

        private static void UpdateRecord(int carId)
        {
            using (var context = new AutoLotEntities())
            {
                var carToUpdate = context.Cars.Find(carId);

                if (carToUpdate != null)
                {
                    Console.WriteLine(context.Entry(carToUpdate).State);
                    carToUpdate.Color = "Magento";
                    Console.WriteLine(context.Entry(carToUpdate).State);
                    context.SaveChanges();
                }
            }
        }

        private static void RemoveRecordUsingEntityState(int carId)
        {
            using (var context = new AutoLotEntities())
            {
                Car carToDelete = new Car { CarId = carId };
                context.Entry(carToDelete).State = EntityState.Deleted;

                try
                {
                    context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        private static void RemoveRecord(int carId)
        {
            using (var context = new AutoLotEntities())
            {
                var carToDelete = context.Cars.Find(carId);
                if (carToDelete != null)
                {
                    context.Cars.Remove(carToDelete);
                    context.SaveChanges();
                }
            }
        }

        private static void PrintInventoriesLinq()
        {
            using (var context = new AutoLotEntities())
            {
                var query = context.Cars
                    .Where(c => c.Make == "ZAZ");

                foreach (var c in query)
                {
                    Console.WriteLine(c);
                }
            }
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

        private static void PrintInventorySQL()
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
