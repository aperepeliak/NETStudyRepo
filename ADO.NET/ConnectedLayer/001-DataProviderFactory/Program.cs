using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;

namespace _001_DataProviderFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            string dataProvider = ConfigurationManager.AppSettings["provider"];
            string connectionString =
                ConfigurationManager.ConnectionStrings["AutoLotSqlProvider"].ConnectionString;

            DbProviderFactory factory = DbProviderFactories.GetFactory(dataProvider);

            using (DbConnection conn = factory.CreateConnection())
            {
                if (conn == null)
                {
                    ShowError("Connection");
                    return;
                }
                Console.WriteLine($"Your connection object is a: {conn.GetType().Name}");
                conn.ConnectionString = connectionString;
                conn.Open();

                var sqlConnection = conn as SqlConnection;
                if (sqlConnection != null)
                {
                    Console.WriteLine($"Version of SQLServer used: {sqlConnection.ServerVersion}");
                }

                DbCommand command = factory.CreateCommand();
                if (command == null)
                {
                    ShowError("Command");
                    return;
                }
                Console.WriteLine($"Your command object is a: {command.GetType().Name}");
                command.Connection = conn;
                command.CommandText = "Select * from Inventory";

                // Print data with DataReader
                using (DbDataReader dataReader = command.ExecuteReader())
                {
                    Console.WriteLine($"Your data reader object is a: {dataReader.GetType().Name}");
                    Console.WriteLine("\nCurrent Inventory");
                    while (dataReader.Read())
                    {
                        Console.WriteLine($" -> Car #{dataReader["CarId"]} is a {dataReader["Make"]}.");
                    }
                }
            }
            Console.ReadLine();
        }

        private static void ShowError(string objectName)
        {
            Console.WriteLine($"There was an issue creating the {objectName}");
            Console.ReadLine();
        }
    }
}
