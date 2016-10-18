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
    public partial class AdminForm : Form
    {
        StoreContext context;
        BindingSource bsGoods;

        public AdminForm()
        {
            InitializeComponent();
            context = new StoreContext();
            bsGoods = new BindingSource();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            context.Goods.Load();
            context.Manufacturers.Load();
            context.Categories.Load();

            List<BusinessGood> data = DisplayGoods.GetGoods(context);

            bsGoods.DataSource = data;
            dgvGoods.DataSource = bsGoods;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void manufacturersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var data = (from m in context.Manufacturers.Local
                        select new { m.ManufacturerId, m.ManufacturerName }).ToList();

            bsGoods.DataSource = null;
            bsGoods.DataSource = data;
            dgvGoods.DataSource = bsGoods;
        }

        private void categoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var data = (from c in context.Categories.Local
                        select new { c.CategoryId, c.CategoryName }).ToList();

            bsGoods.DataSource = null;
            bsGoods.DataSource = data;
            dgvGoods.DataSource = bsGoods;
        }

        private void goodsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<BusinessGood> data = DisplayGoods.GetGoods(context);
            bsGoods.DataSource = null;
            bsGoods.DataSource = data;
            dgvGoods.DataSource = bsGoods;
        }
    }
}
