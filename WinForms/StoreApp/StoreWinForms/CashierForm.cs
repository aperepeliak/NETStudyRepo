using StoreDataLayer.BusinessLayer;
using StoreDataLayer.DbLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreWinForms
{
    public partial class CashierForm : Form
    {
        StoreContext context;
        BindingSource bSource;
        List<BusinessGood> dataGood;



        public CashierForm()
        {
            InitializeComponent();
            context = new StoreContext();
            bSource = new BindingSource();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CashierForm_Load(object sender, EventArgs e)
        {
            context.Goods.Load();
            context.Manufacturers.Load();
            context.Categories.Load();
            context.Sales.Load();
            context.SalePos.Load();

            dataGood = DisplayGoods.GetGoods(context);

            bSource.DataSource = dataGood;
            dgvGoods.DataSource = bSource;
        }

        private void dgvGoods_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }
    }
}
