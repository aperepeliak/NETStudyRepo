
//using ConsoleClientTestApp.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using GenericServiceLib.Repos;
using GenericServiceLib.Models;
using GenericServiceLib;

namespace ConsoleClientTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Testing Lib
            CategoryRepo test = new CategoryRepo();

            Contract contract = new Contract();

            var cat = contract.GetCategories();

            test.Add(new Category { Id = 2, Name = "Scanner" });

            var a = test.GetAll();

            foreach (var i in a)
            {
                Console.WriteLine($"Id: {i.Id} Name: {i.Name}");
            }

            test.Save();

            Console.ReadLine();

            #endregion

            //var client = new ContractClient("NetTcpBinding_IContract", "net.tcp://localhost:8081/Contract");

            //CategoryRepo catRepo = client.GetCategories();

            //foreach (var i in catRepo.Table)
            //{
            //    Console.WriteLine($"ID: {i.Idk__BackingField} Name: {i.Namek__BackingField}");
            //}

            //Console.WriteLine("\n\nPress Enter...");
            //Console.ReadLine();
        }
    }
}
