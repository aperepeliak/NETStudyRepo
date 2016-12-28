using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _002_WindowsFormsDataBinding
{
    public partial class MainForm : Form
    {
        List<Car> listCars = null;
        DataTable invTable = new DataTable();

        public MainForm()
        {
            InitializeComponent();

            listCars = new List<Car>
            {
                new Car {Id = 1, PetName = "Chucky", Make = "BMW", Color = "Black" },
                new Car {Id = 2, PetName = "Dizzy", Make = "Saab", Color = "Green" },
                new Car {Id = 3, PetName = "Charlie", Make = "ZAZ", Color = "Pink" },
                new Car {Id = 4, PetName = "Bobby", Make = "Ford", Color = "Navy" },
                new Car {Id = 5, PetName = "Sam", Make = "GM", Color = "White" }
            };

            CreateDataTable();
        }

        private void CreateDataTable()
        {
            var carIDColumn = new DataColumn("Id", typeof(int));
            var carPetNameColumn = new DataColumn("PetName", typeof(string)) { Caption = "Pet Name" };
            var carMakeColumn = new DataColumn("Make", typeof(string));
            var carColorColumn = new DataColumn("Color", typeof(string));

            invTable.Columns.AddRange(new[] { carIDColumn, carPetNameColumn, carMakeColumn, carColorColumn });

            foreach (var c in listCars)
            {
                var newRow = invTable.NewRow();
                newRow["Id"] = c.Id;
                newRow["Make"] = c.Make;
                newRow["Color"] = c.Color;
                newRow["PetName"] = c.PetName;
                invTable.Rows.Add(newRow);
            }

            carInvGridView.DataSource = invTable;
        }

        private void btnRemoveCar_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow[] rowToDelete = invTable.Select($"Id={int.Parse(txtCarToRemove.Text)}");
                rowToDelete[0].Delete();
                invTable.AcceptChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            var filterStr = $"Make='{txtViewMake.Text}'";

            // Find all rows matching the filter
            DataRow[] makes = invTable.Select(filterStr);

            if (makes.Length == 0)
            {
                MessageBox.Show("Sorry, no cars...", "Selection error!");
            } else
            {
                string strMake = null;
                for (int i = 0; i < makes.Length; i++)
                {
                    strMake += makes[i]["PetName"] + "\n";
                }
                MessageBox.Show(strMake, $"We have {txtViewMake.Text}s named: ");
            }
        }
    }
}
