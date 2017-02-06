using NinjaDomain.Classes;
using NinjaDomain.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new NullDatabaseInitializer<NinjaContext>());
            // InsertNinja();
            QueryNinjas();
        }

        private static void QueryNinjas()
        {
            using (var context = new NinjaContext())
            {
                var ninjas = context.Ninjas
                    .Where(n => n.DateOfBirth >= new DateTime(1990, 1, 1))
                    .ToList();

                foreach (var i in ninjas)
                {
                    Console.WriteLine(i.Name, i.Id);
                }
            }
        }

        private static void InsertNinja()
        {
            var ninja = new Ninja
            {
                Name = "Vasya",
                ServedInOniwaban = false,
                DateOfBirth = new DateTime(1995, 2, 2),
                ClanId = 1
            };

            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                context.Ninjas.Add(ninja);
                context.SaveChanges();
            }
        }
    }
}
