using AutoLotDAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLotDAL.EF
{
    public class DataInitializer : DropCreateDatabaseAlways<AutoLotEntities>
    {
        protected override void Seed(AutoLotEntities context)
        {
            var customers = new List<Customer>
            {
                new Customer { FirstName = "Dave", LastName = "Brenner" },
                new Customer { FirstName = "Matt", LastName = "Walton" },
                new Customer { FirstName = "Steve", LastName = "Hagen" },
                new Customer { FirstName = "Pat", LastName = "Walton" },
                new Customer { FirstName = "Bad", LastName = "Customer" }
            };

            customers.ForEach(x => context.Customers.Add(x));

            var cars = new List<Inventory>
            {
                new Inventory { Make = "VW", Color = "Black", PetName = "Zippy" },
                new Inventory { Make = "Ford", Color = "Rust", PetName = "Rusty" },
                new Inventory { Make = "ZAZ", Color = "Pink", PetName = "Lola" },
                new Inventory { Make = "Saab", Color = "Green", PetName = "Mel" },
                new Inventory { Make = "Jeep", Color = "Navy", PetName = "Sam" },
                new Inventory { Make = "BWM", Color = "White", PetName = "Bob" },
                new Inventory { Make = "BWM", Color = "Yellow", PetName = "Carl" },
            };

            cars.ForEach(x => context.Inventory.Add(x));

            var orders = new List<Order>
            {
                new Order { Car = cars[0], Customer = customers[0] },
                new Order { Car = cars[1], Customer = customers[1] },
                new Order { Car = cars[2], Customer = customers[2] },
                new Order { Car = cars[3], Customer = customers[3] },
            };

            orders.ForEach(x => context.Orders.Add(x));

            context.CreditRisks.Add(new CreditRisk
            {
                CustId = customers[4].CustId,
                FirstName = customers[4].FirstName,
                LastName = customers[4].LastName
            });

            context.SaveChanges();
        }
    }
}
