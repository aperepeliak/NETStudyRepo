using AutoLotDAL.ConnectedLayer;
using AutoLotDAL.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLotCUIClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** The AutoLot Console UI *****\n");

            string connectionString =
                ConfigurationManager.ConnectionStrings["AutoLotSqlProvider"].ConnectionString;

            bool userDone = false;
            string userCommand = "";

            // Creating InventoryDAL object
            InventoryDAL invDAL = new InventoryDAL();
            invDAL.OpenConnection(connectionString);

            // Keep asking for input until user presses the Q key
            try
            {
                ShowInstructions();
                do
                {
                    Console.Write("\nPlease enter your command: ");
                    userCommand = Console.ReadLine();
                    Console.WriteLine();
                    switch (userCommand?.ToUpper() ?? "")
                    {
                        case "I":
                            InsertNewCar(invDAL);
                            break;

                        case "U":
                            UpdateCarPetName(invDAL);
                            break;

                        case "D":
                            DeleteCar(invDAL);
                            break;

                        case "L":
                            ListInventory(invDAL);
                            break;

                        case "S":
                            ShowInstructions();
                            break;

                        case "P":
                            LookUpPetName(invDAL);
                            break;

                        case "Q":
                            userDone = true;
                            break;

                        default:
                            Console.WriteLine("Invalid data. Please, try again.");
                            break;
                    }
                } while (!userDone);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                invDAL.CloseConnection();
            }
        }

        private static void LookUpPetName(InventoryDAL invDAL)
        {
            Console.Write("Enter Car ID: ");
            var carID = int.Parse(Console.ReadLine() ?? "0");
            Console.WriteLine($"Petname of {carID} is {invDAL.LookUpPetName(carID).TrimEnd()}.");
        }

        private static void ListInventory(InventoryDAL invDAL)
        {
            List<NewCar> record = invDAL.GetAllInventoryAsList();
            Console.WriteLine("CarId:\tMake:\tColor:\tPetName:");
            foreach (var c in record)
            {
                Console.WriteLine($"{c.CarId}\t{c.Make}\t{c.Color}\t{c.PetName}");
            }
        }

        private static void DeleteCar(InventoryDAL invDAL)
        {
            Console.Write("Enter ID of Car to delete: ");
            int id = int.Parse(Console.ReadLine() ?? "0");

            try
            {
                invDAL.DeleteCar(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void UpdateCarPetName(InventoryDAL invDAL)
        {
            Console.Write("Enter Car ID: ");
            var carID = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Enter new PetName: ");
            var newPetName = Console.ReadLine();

            invDAL.UpdateCarPetName(carID, newPetName);
        }

        private static void InsertNewCar(InventoryDAL invDAL)
        {
            Console.Write("Enter Car ID: ");
            var newCarId = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Enter Car color: ");
            var newCarColor = Console.ReadLine();
            Console.Write("Enter Car Make: ");
            var newCarMake = Console.ReadLine();
            Console.Write("Enter Car PetName: ");
            var newCarPetName = Console.ReadLine();

            invDAL.InsertAuto(new NewCar
            {
                CarId = newCarId,
                Color = newCarColor,
                Make = newCarMake,
                PetName = newCarPetName
            });
        }

        private static void ShowInstructions()
        {
            Console.WriteLine("I: Inserts new car.");
            Console.WriteLine("U: Updates an existing car.");
            Console.WriteLine("D: Deletes an existing car.");
            Console.WriteLine("L: Lists current inventory.");
            Console.WriteLine("S: Shows these instructions.");
            Console.WriteLine("P: Looks up pet name.");
            Console.WriteLine("Q: Quits program.");
        }
    }
}
