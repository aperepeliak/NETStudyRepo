using AutoLotDAL.ConnectedLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetTransaction
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Transaction example\n");

            bool throwEx = true;

            Console.Write("Would you like to throw an exception (Y/N): ");
            var userAnswer = Console.ReadLine();

            if (userAnswer?.ToLower() == "n")
            {
                throwEx = false;
            }

            var invDAL = new InventoryDAL();
            var connectionString =
                ConfigurationManager.ConnectionStrings["AutoLotSqlProvider"].ConnectionString;
            invDAL.OpenConnection(connectionString);

            invDAL.ProcessCreditRisk(throwEx, 5);
            Console.WriteLine("Check CreditRisks table for results");
            Console.ReadLine();
        }
    }
}
