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
        BindingSource bSource;

        public AdminForm()
        {
            InitializeComponent();
            context = new StoreContext();
            bSource = new BindingSource();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            context.Goods.Load();
            context.Manufacturers.Load();
            context.Categories.Load();

            List<BusinessGood> data = DisplayGoods.GetGoods(context);

            bSource.DataSource = data;
            dgvGoods.DataSource = bSource;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void manufacturersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<BusinessManufacturer> data = DisplayManufacturers.GetManufacturers(context);

            bSource.DataSource = null;
            bSource.DataSource = data;
            dgvGoods.DataSource = bSource;

            btnAddPhoto.Enabled = false;
            btnRemovePhoto.Enabled = false;
        }

        private void categoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<BusinessCategory> data = DisplayCategory.GetCategories(context);

            bSource.DataSource = null;
            bSource.DataSource = data;
            dgvGoods.DataSource = bSource;

            btnAddPhoto.Enabled = false;
            btnRemovePhoto.Enabled = false;
        }

        private void goodsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<BusinessGood> data = DisplayGoods.GetGoods(context);
            bSource.DataSource = null;
            bSource.DataSource = data;
            dgvGoods.DataSource = bSource;

            btnAddPhoto.Enabled = true;
            btnRemovePhoto.Enabled = true;
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bSource.Current is BusinessGood)
            {
                var item = bSource.Current as BusinessGood;

                GoodManipForm editGood = new GoodManipForm(context, item.GoodId);
                editGood.ShowDialog();
                RefreshDgv();
            }
            else if (bSource.Current is BusinessManufacturer)
            {
                MessageBox.Show("Manuf");
            }
            else
            {
                MessageBox.Show("Cat");
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bSource.Current is BusinessGood)
            {
                GoodManipForm addGood = new GoodManipForm(context);

                addGood.ShowDialog();
                RefreshDgv();
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bSource.Current is BusinessGood)
            {
                BusinessGood item = bSource.Current as BusinessGood;
                DialogResult confirmDeletion = MessageBox.Show($"Are you sure you would like to delete {item.GoodName}?", "Confirmation", MessageBoxButtons.YesNo);

                if (confirmDeletion == DialogResult.Yes)
                {
                    Good good = context.Goods.Local
                    .Where(g => g.GoodId == item.GoodId)
                    .FirstOrDefault();

                    context.Goods.Remove(good);
                    context.SaveChanges();
                    RefreshDgv();
                }
            }
        }

        private void RefreshDgv()
        {
            dgvGoods.DataSource = null;
            List<BusinessGood> data = DisplayGoods.GetGoods(context);
            bSource.DataSource = data;
            dgvGoods.DataSource = bSource;
        }
    }
}
