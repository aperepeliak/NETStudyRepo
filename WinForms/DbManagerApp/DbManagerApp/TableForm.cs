using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DbManagerApp
{
    class TableForm : Form
    {
        private DataGridView dgv;
        private ToolBar tlb;

        public TableForm(string tableName, SQLiteConnection con)
        {
            Text = tableName;
            Name = tableName;
            Size = new System.Drawing.Size(700, 400);

            dgv = new DataGridView();
            GetData(tableName, con);
            dgv.ReadOnly = true;

            tlb = new ToolBar();

            tlb.Appearance = ToolBarAppearance.Flat;
            tlb.BorderStyle = BorderStyle.Fixed3D;
            
            tlb.ButtonSize = new System.Drawing.Size(24, 24);
            tlb.TextAlign = ToolBarTextAlign.Right;

            tlb.Buttons.Add("Edit");
            tlb.Buttons.Add("Add");
            tlb.Buttons.Add("Delete");
            tlb.Buttons.Add("Insert");

            tlb.Dock = DockStyle.Top;
            dgv.Dock = DockStyle.Fill;
            dgv.ColumnHeadersVisible = true;
            Controls.Add(dgv);
            Controls.Add(tlb);

            tlb.ButtonClick += tlbClicked;
        }

        private void GetData(string tableName, SQLiteConnection con)
        {
            con.Open();
            SQLiteCommand cmd = new SQLiteCommand(con);

            cmd.CommandText = "Select * from " + tableName + ";";

            SQLiteDataReader dataReader = cmd.ExecuteReader();

            string[] rows = new string[dataReader.FieldCount];

            // Adding columns names
            DataGridViewColumn[] columns = new DataGridViewColumn[dataReader.FieldCount];
            for (int i = 0; i < dataReader.FieldCount; i++)
            {
                Console.WriteLine($"{dataReader.GetName(i)}");
                columns[i] = new DataGridViewColumn();
                columns[i].Name = dataReader.GetName(i);
                columns[i].CellTemplate = new DataGridViewTextBoxCell();
                dgv.Columns.Add(columns[i]);
            }

            // Inserting data to dataGridView
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        rows[i] = dataReader.GetValue(i).ToString();
                    }
                    dgv.Rows.Add(rows);
                }
            }
            else
            {
                Console.WriteLine("The table is empty");
            }
            dataReader.Close();

            con.Close();
        }

        private void tlbClicked(object sender, ToolBarButtonClickEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
