using AutoLotDAL2.ConnectedLayer;
using AutoLotDAL2.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString =
                ConfigurationManager.ConnectionStrings["AutoLotSqlProvider"].ConnectionString;
            var _db = new InventoryDAL(connectionString);

            string name = _db.Universal(_db.LookUpPetName, 3);

            List<NewCar> cars;
            using (var db = new InventoryDAL(connectionString))
            {
                // db.InsertAuto(new NewCar { Color = "Red", Make = "Ferrari", PetName = "Lucia" });
                // Console.WriteLine(db.LookUpPetName(18)); 
            }

            //foreach (var c in cars)
            //{
            //    Console.WriteLine($"{c.CarId}\t{c.Make}\t{c.Color}\t{c.PetName}");
            //}
        }
    }
}
