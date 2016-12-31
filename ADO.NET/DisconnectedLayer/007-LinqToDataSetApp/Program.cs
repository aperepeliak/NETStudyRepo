using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoLotDAL.DataSets;
using AutoLotDAL.DataSets.AutoLotDataSetTableAdapters;
using System.Data;

namespace _007_LinqToDataSetApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var tableAdapter = new InventoryTableAdapter();
            var data = tableAdapter.GetData();

            // PrintAllCarIDs(data);
            // ShowBlackCars(data);
            BuildDataTableFromQuery(data);

            Console.ReadLine();
        }

        private static void PrintAllCarIDs(DataTable data)
        {
            EnumerableRowCollection enumData = data.AsEnumerable();
            foreach (DataRow r in enumData)
            {
                Console.WriteLine($"Car ID : {r["CarID"]}");
            }
        }

        private static void ShowBlackCars(DataTable data)
        {
            var query = data
                .AsEnumerable()
                .Where(c => (string)c["Color"] == "Black")
                .Select(c => new
                {
                    ID = c.Field<int>("CarID"),
                    Make = c.Field<string>("Make")
                });

            Console.WriteLine("Here are the black cars we have: ");
            foreach (var car in query)
            {
                Console.WriteLine($" -> ID: {car.ID} \tMake: {car.Make}");
            }
        }

        static void BuildDataTableFromQuery(DataTable data)
        {
            var cars =
                data
                .AsEnumerable()
                .Where(c => c.Field<int>("CarID") > 5);

            var newTable = cars.CopyToDataTable();

            // Print the DataTable
            var dataReader = newTable.CreateDataReader();

            while (dataReader.Read())
            {
                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    Console.Write($"{dataReader.GetValue(i).ToString().Trim()}\t");
                }
                Console.WriteLine();
            }

            dataReader.Close();
        }
    }
}
