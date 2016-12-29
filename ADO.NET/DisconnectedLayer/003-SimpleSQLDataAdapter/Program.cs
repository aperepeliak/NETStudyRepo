using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _003_SimpleSQLDataAdapter
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString =
                ConfigurationManager.ConnectionStrings["AutoLotSqlProvider"].ConnectionString;
            var ds = new DataSet("AutoLot");
            var adapter = new SqlDataAdapter("Select * from Inventory", connectionString);

            var tableMapping = adapter.TableMappings.Add("Inventory", "Current Inventory");
            tableMapping.ColumnMappings.Add("CarId", "Car ID");
            tableMapping.ColumnMappings.Add("PetName", "Name of Car");

            adapter.Fill(ds, "Inventory");
            PrintDataSet(ds);
        }

        private static void PrintTable(DataTable dt)
        {
            DataTableReader dtReader = dt.CreateDataReader();

            while (dtReader.Read())
            {
                for (int i = 0; i < dtReader.FieldCount; i++)
                {
                    Console.Write($"{dtReader.GetValue(i).ToString().Trim()}\t");
                }
                Console.WriteLine();
            }
            dtReader.Close();
        }

        private static void PrintDataSet(DataSet ds)
        {
            Console.WriteLine($"DataSet is named: {ds.DataSetName}");
            foreach (DictionaryEntry de in ds.ExtendedProperties)
            {
                Console.WriteLine($"Key = {de.Key}, Value = {de.Value}");
            }
            Console.WriteLine();

            foreach (DataTable dt in ds.Tables)
            {
                Console.WriteLine($"=> {dt.TableName} Table: ");

                for (int curCol = 0; curCol < dt.Columns.Count; curCol++)
                {
                    Console.Write($"{dt.Columns[curCol].ColumnName.Trim()}\t");
                }
                Console.WriteLine("\n-----------------------------------");

                PrintTable(dt);
            }
        }
    }
}
