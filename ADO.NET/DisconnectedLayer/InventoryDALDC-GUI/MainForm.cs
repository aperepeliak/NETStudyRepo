using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AutoLotDAL.DisconnectedLayer;

namespace InventoryDALDC_GUI
{
    public partial class MainForm : Form
    {
        InventoryDALDC _dal = null;

        public MainForm()
        {
            InitializeComponent();

            string cnStr = @"Data Source=(local)\SQLEXPRESS;Initial Catalog=Autolot;" +
                "Integrated Security=True;Pooling=False";

            _dal = new InventoryDALDC(cnStr);

            invGrid.DataSource = _dal.GetAllInventory();
        }

        private void btnUpdateInv_Click(object sender, EventArgs e)
        {
            var changedDT = (DataTable)invGrid.DataSource;

            try
            {
                _dal.UpdateInventory(changedDT);
                invGrid.DataSource = _dal.GetAllInventory();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
