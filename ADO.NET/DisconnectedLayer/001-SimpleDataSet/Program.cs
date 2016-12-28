using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_SimpleDataSet
{
    class Program
    {
        static void Main(string[] args)
        {
            var carsInventory = new DataSet("Car Inventory");

            // As an option
            // carsInventory.ReadXml("carsDataSet.xml");

            carsInventory.ExtendedProperties["TimeStamp"] = DateTime.Now;
            carsInventory.ExtendedProperties["DataSetID"] = Guid.NewGuid();
            carsInventory.ExtendedProperties["Company"] = "Ingul";

            FillDataSet(carsInventory);

            PrintDataSet(carsInventory);

            // SaveAndLoadAsXml(carsInventory);

            // ManipulateDataRowState();

            Console.ReadLine();
        }

        private static void SaveAndLoadAsXml(DataSet ds)
        {
            // Save
            ds.WriteXml("carsDataSet.xml");
            ds.WriteXmlSchema("carsDataSet.xsd");

            // Clear out DataSet
            ds.Clear();

            // Load ds from file
            ds.ReadXml("carsDataSet.xml");
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

                //for (int curRow = 0; curRow < dt.Rows.Count; curRow++)
                //{
                //    for (int curCol = 0; curCol < dt.Columns.Count; curCol++)
                //    {
                //        Console.Write($"{dt.Rows[curRow][curCol]}\t");
                //    }
                //    Console.WriteLine();
                //}
            }
        }

        private static void FillDataSet(DataSet ds)
        {
            var carIDColumn = new DataColumn("CarID", typeof(int))
            {
                Caption = "Car ID",
                ReadOnly = true,
                AllowDBNull = true,
                Unique = true,
                AutoIncrement = true,
                AutoIncrementSeed = 1,
                AutoIncrementStep = 1
            };

            var carMakeColumn = new DataColumn("Make", typeof(string));
            var carColorColumn = new DataColumn("Color", typeof(string));
            var carPetNameColumn = new DataColumn("PetName", typeof(string))
            {
                Caption = "Pet Name"
            };

            var inventoryTable = new DataTable("Inventory");
            inventoryTable.Columns.AddRange(new[]
            {
                carIDColumn, carMakeColumn, carColorColumn, carPetNameColumn
            });

            inventoryTable.PrimaryKey = new[] { inventoryTable.Columns[0] };

            DataRow carRow = inventoryTable.NewRow();
            carRow["Make"] = "BMW";
            carRow["Color"] = "White";
            carRow["PetName"] = "Hamlet";
            inventoryTable.Rows.Add(carRow);

            carRow = inventoryTable.NewRow();
            carRow[1] = "Saab";
            carRow[2] = "Green";
            carRow[3] = "Dizzy";
            inventoryTable.Rows.Add(carRow);

            ds.Tables.Add(inventoryTable);
        }

        private static void ManipulateDataRowState()
        {
            var temp = new DataTable("Temp");
            temp.Columns.Add(new DataColumn("TempColumn", typeof(int)));

            // RowState = Detached 
            var row = temp.NewRow();
            Console.WriteLine($"After calling NewRow(): {row.RowState}");

            // RowState = Added
            temp.Rows.Add(row);
            Console.WriteLine($"After calling Rows.Add(): {row.RowState}");

            // RowState = Added
            row["TempColumn"] = 10;
            Console.WriteLine($"After first assignment: {row.RowState}");

            // Unchanged
            temp.AcceptChanges();
            Console.WriteLine($"After calling AcceptChanges(): {row.RowState}");

            // Modified
            row["TempColumn"] = 11;
            Console.WriteLine($"After second assignment: {row.RowState}");

            // Deleted
            temp.Rows[0].Delete();
            Console.WriteLine($"After calling Delete(): {row.RowState}");
        }
    }
}
