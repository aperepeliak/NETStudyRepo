using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace _002_AutoLotDataReader
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString =
                ConfigurationManager.ConnectionStrings["AutoLotSqlProvider"].ConnectionString;
            var connStringBuilder = new SqlConnectionStringBuilder(connectionString);
            connStringBuilder.ConnectTimeout = 5;

            using (var connection = new SqlConnection())
            {
                connection.ConnectionString = connStringBuilder.ConnectionString;
                connection.Open();

                string query = "Select * from Inventory";
                var command = new SqlCommand(query, connection);

                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        Console.WriteLine
                            ($" -> Make: {dataReader["Make"]}, PetName: {dataReader["PetName"]}, Color: {dataReader["Color"]}");
                    }
                }
            }
            Console.ReadLine();
        }
    }
}
