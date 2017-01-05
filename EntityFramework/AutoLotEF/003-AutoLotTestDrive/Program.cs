using AutoLotDAL.EF;
using AutoLotDAL.Models;
using AutoLotDAL.Repos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _003_AutoLotTestDrive
{
    class Program
    {
        static void Main(string[] args)
        {
            // Database.SetInitializer(new DataInitializer());

            //var car1 = new Inventory { Make = "VAZ", Color = "Red", PetName = "Ladushka" };
            //var car2 = new Inventory { Make = "Subaru", Color = "SeaBreeze", PetName = "Fudzi" };

            //AddNewRecord(car1);
            //AddNewRecord(car2);

            //AddNewRecords(new List<Inventory> { car1, car2 });

            // UpdateRecord(car2.CarId);
            // PrintAllInventory();
            // ShowAllOrders();
            // ShowAllOrdersEagerlyFetched();

            PrintAllCustomersAndCreditRisks();

            var customerRepo = new CustomerRepo();
            var customer = customerRepo.GetOne(4);
            customerRepo.Context.Entry(customer).State = EntityState.Detached;
            var risk = MakeCustomerARisk(customer);

            PrintAllCustomersAndCreditRisks();

            // Console.ReadLine();
        }

        private static void PrintAllCustomersAndCreditRisks()
        {
            Console.WriteLine("==== Customers ====");
            using (var repo = new CustomerRepo())
            {
                foreach (var cust in repo.GetAll())
                {
                    Console.WriteLine($" -> {cust.FullName} is a Customer");
                }
            }
            Console.WriteLine("==== Credit Risks ====");
            using (var repo = new CreditRiskRepo())
            {
                foreach (var cr in repo.GetAll())
                {
                    Console.WriteLine($" -> {cr.FirstName} {cr.LastName} is a Credit Risk!");
                }
            }
        }

        private static CreditRisk MakeCustomerARisk(Customer customer)
        {
            using (var context = new AutoLotEntities())
            {
                context.Customers.Attach(customer);
                context.Customers.Remove(customer);
                var creditRisk = new CreditRisk
                {
                    FirstName = customer.FirstName,
                    LastName = customer.LastName
                };

                context.CreditRisks.Add(creditRisk);

                try
                {
                    context.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    Console.WriteLine(ex);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                return creditRisk;
            }
        }

        private static void ShowAllOrdersEagerlyFetched()
        {
            using (var context = new AutoLotEntities())
            {
                Console.WriteLine("==== Pending orders ====");
                var orders = context.Orders
                    .Include(x => x.Customer)
                    .Include(x => x.Car)
                    .ToList();

                foreach (var o in orders)
                {
                    Console.WriteLine($" -> {o.Customer.FullName} is waiting on {o.Car.PetName}");
                }
            }
        }

        private static void ShowAllOrders()
        {
            using (var repo = new OrderRepo())
            {
                Console.WriteLine("*** Pending Orders ***");
                foreach (var item in repo.GetAll())
                {
                    Console.WriteLine($" -> {item.Customer.FullName} is waiting on {item.Car.PetName}");
                }
            }
        }

        private static void UpdateRecord(int carId)
        {
            using (var repo = new InventoryRepo())
            {
                var carToUpdate = repo.GetOne(carId);
                if (carToUpdate != null)
                {
                    Console.WriteLine("Before change: " + repo.Context.Entry(carToUpdate).State);
                    carToUpdate.Color = "Magento";
                    Console.WriteLine("After change: " + repo.Context.Entry(carToUpdate).State);
                    repo.Save(carToUpdate);
                    Console.WriteLine("After save: " + repo.Context.Entry(carToUpdate).State);
                }
            }
        }

        private static void PrintAllInventory()
        {
            using (var repo = new InventoryRepo())
            {
                foreach (var c in repo.GetAll())
                {
                    Console.WriteLine(c);
                }
            }
        }

        private static void AddNewRecord(Inventory car)
        {
            using (var repo = new InventoryRepo())
            {
                repo.Add(car);
            }
        }

        private static void AddNewRecords(IList<Inventory> cars)
        {
            using (var repo = new InventoryRepo())
            {
                repo.AddRange(cars);
            }
        }
    }
}
