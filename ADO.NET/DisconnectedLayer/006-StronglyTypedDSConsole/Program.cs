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
    }
}
