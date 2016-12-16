using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Excel = Microsoft.Office.Interop.Excel;

namespace ExportDataToOfficeApp
{
    public partial class MainForm : Form
    {

        List<Car> carsInStock = null;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            carsInStock = new List<Car>()
            {
                new Car {Color = "Green", Make = "VW", PetName = "Dizzy" },
                new Car {Color = "Red", Make = "Toyota", PetName = "Mike" },
                new Car {Color = "Black", Make = "ZAZ", PetName = "Andrew" },
                new Car {Color = "Yellow", Make = "VAZ", PetName = "Vasya" },
                new Car {Color = "Blue", Make = "Subaru", PetName = "Mizo" },
            };

            UpdateGrid();
        }

        private void UpdateGrid()
        {
            dataGridCars.DataSource = null;
            dataGridCars.DataSource = carsInStock;
        }

        private void btnAddToInventory_Click(object sender, EventArgs e)
        {
            NewCarDialog dlg = new NewCarDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                carsInStock.Add(dlg.theCar);
                UpdateGrid();
            }
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel(carsInStock);
        }

        private void ExportToExcel(List<Car> carsInStock)
        {
            // Load up Excel, then make a new empty workbook
            Excel.Application excelApp = new Excel.Application();

            // Optional
            excelApp.Visible = true;

            excelApp.Workbooks.Add();

            // This example uses a single worksheet
            Excel._Worksheet workSheet = excelApp.ActiveSheet;

            // Establish column headings in cells
            workSheet.Cells[1, "A"] = "Make";
            workSheet.Cells[1, "B"] = "Color";
            workSheet.Cells[1, "C"] = "Pet Name";

            // Map all data in List<Car> to the cells of the spreadsheet
            int row = 1;
            foreach (Car c in carsInStock)
            {
                row++;
                workSheet.Cells[row, "A"] = c.Make;
                workSheet.Cells[row, "B"] = c.Color;
                workSheet.Cells[row, "C"] = c.PetName;
            }

            // Style table
            workSheet.Range["A1"].AutoFormat(
                Excel.XlRangeAutoFormat.xlRangeAutoFormatClassic2);

            // Save the file, quit Excel, and display message to user
            workSheet.SaveAs(string.Format(@"{0}\Inventory.xlsx", Environment.CurrentDirectory));
            excelApp.Quit();
            MessageBox.Show("The Inventory.xlsx file has been saved to your app folder",
                "Export complete!");
        }
    }
}
