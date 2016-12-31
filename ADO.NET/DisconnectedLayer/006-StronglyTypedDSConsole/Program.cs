using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoLotDAL.DataSets;
using AutoLotDAL.DataSets.AutoLotDataSetTableAdapters;

namespace _006_StronglyTypedDSConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var table = new AutoLotDataSet.InventoryDataTable();
            var adapter = new InventoryTableAdapter();

            AddRecords(table, adapter);
            table.Clear();
            adapter.Fill(table);
            PrintInventory(table);
            Console.ReadLine();
        }

        private static void PrintInventory(AutoLotDataSet.InventoryDataTable table)
        {
            for (int curCol = 0; curCol < table.Columns.Count; curCol++)
            {
                Console.Write(table.Columns[curCol].ColumnName + "\t");
            }
            Console.WriteLine("\n-------------------------------------");

            for (int curRow = 0; curRow < table.Rows.Count; curRow++)
            {
                for (int curCol = 0; curCol < table.Columns.Count; curCol++)
                {
                    Console.Write(table.Rows[curRow][curCol] + "\t");
                }
                Console.WriteLine();
            }
        }

        public static void AddRecords(AutoLotDataSet.InventoryDataTable table,
            InventoryTableAdapter adapter)
        {
            try
            {
                AutoLotDataSet.InventoryRow newRow = table.NewInventoryRow();
                newRow.Color = "Purple";
                newRow.Make = "BMW";
                newRow.PetName = "Carl";

                table.AddInventoryRow(newRow);
                table.AddInventoryRow("Yugo", "Green", "Zippy");

                adapter.Update(table);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
