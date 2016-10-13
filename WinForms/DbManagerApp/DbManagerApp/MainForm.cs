using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DbManagerApp
{
    /// <summary>
    /// Main menu form class
    /// </summary>
    class MainForm : Form
    {
        SQLiteConnection con;
        Button btn_openTbl;
        Button btn_createTbl;
        Label lbl_status;
        ListBox lbx_availableTables;
        TableLayoutPanel tablePanel;


        public MainForm(string dbPath)
        {
            bool conStatus = ConnectToDB(dbPath);

            if (conStatus)
            {
                // Label config
                lbl_status = new Label();
                lbl_status.AutoSize = true;
                lbl_status.Text = "Connected to : " + dbPath.Split('\\')[2];

                // ListBox config
                lbx_availableTables = new ListBox();
                lbx_availableTables.Dock = DockStyle.Fill;
                lbx_availableTables.DataSource = ListTables();

                // Buttons
                btn_openTbl = new Button();
                btn_openTbl.Click += OpenTable;

                btn_openTbl.Text = "Open table";

                btn_createTbl = new Button();
                btn_createTbl.Text = "Create table";

                // Table layout config
                tablePanel = new TableLayoutPanel();
                tablePanel.AutoSize = true;
                tablePanel.Padding = new Padding(10);

                tablePanel.Controls.Add(lbl_status, 1, 1);
                tablePanel.Controls.Add(lbx_availableTables, 1, 2);
                tablePanel.Controls.Add(btn_openTbl, 1, 3);
                tablePanel.Controls.Add(btn_createTbl, 1, 4);

                con.Close();
            }
            else
            {
                MessageBox.Show("Failed to connect.");
            }

            Controls.Add(tablePanel);
        }

        private void OpenTable(object sender, EventArgs e)
        {
            string selectedTable = lbx_availableTables.SelectedItem.ToString();
            OpenSelectedTable(selectedTable);
        }

        private void OpenSelectedTable(string selectedTable)
        {
            var openForm = Application.OpenForms.Cast<Form>().Where(x => x.Name == selectedTable).FirstOrDefault();
            if (openForm != null)
            {
                openForm.Focus();
            }
            else
            {
                TableForm newTableForm = new TableForm(selectedTable, con);
                newTableForm.Visible = true;
            }
        }

        private List<string> ListTables()
        {
            List<string> tables = new List<string>();
            DataTable dt = con.GetSchema("Tables");
            foreach (DataRow row in dt.Rows)
            {
                string tablename = (string)row[2];
                tables.Add(tablename);
            }
            return tables;
        }

        private bool ConnectToDB(string dbPath)
        {

            con = new SQLiteConnection("Data Source=" + dbPath);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
