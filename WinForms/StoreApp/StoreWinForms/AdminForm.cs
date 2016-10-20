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
        List<BusinessGood> dataGood;
        List<BusinessManufacturer> dataManufacturer;
        List<BusinessCategory> dataCategory;

        public enum Entity { Manufacturer, Category };

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

            dataGood = DisplayGoods.GetGoods(context);

            bSource.DataSource = dataGood;
            dgvGoods.DataSource = bSource;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void manufacturersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataManufacturer = DisplayManufacturers.GetManufacturers(context);

            bSource.DataSource = null;
            bSource.DataSource = dataManufacturer;
            dgvGoods.DataSource = bSource;

            btnAddPhoto.Enabled = false;
            btnRemovePhoto.Enabled = false;
            flwPhoto.Enabled = false;
        }

        private void categoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataCategory = DisplayCategory.GetCategories(context);

            bSource.DataSource = null;
            bSource.DataSource = dataCategory;
            dgvGoods.DataSource = bSource;

            btnAddPhoto.Enabled = false;
            btnRemovePhoto.Enabled = false;
            flwPhoto.Enabled = false;
        }

        private void goodsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGood = DisplayGoods.GetGoods(context);
            bSource.DataSource = null;
            bSource.DataSource = dataGood;
            dgvGoods.DataSource = bSource;

            btnAddPhoto.Enabled = true;
            btnRemovePhoto.Enabled = true;
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bSource.Current is BusinessGood)
            {
                var item = bSource.Current as BusinessGood;

                GoodManipForm edit = new GoodManipForm(context, item.GoodId);
                edit.ShowDialog();
                RefreshDgv();
            }
            else if (bSource.Current is BusinessManufacturer)
            {
                var item = bSource.Current as BusinessManufacturer;
                ManufCatManipForm edit = new ManufCatManipForm(context, Entity.Manufacturer, item.ManufacturerId);
                edit.txtManufCat.Text = item.ManufacturerName;
                DialogResult res = edit.ShowDialog();

                if (res == DialogResult.OK)
                {
                    foreach (var m in dataManufacturer)
                    {
                        if (m.ManufacturerId == item.ManufacturerId)
                        {
                            m.ManufacturerName = edit.txtManufCat.Text;
                        }
                    }
                }
            }
            else
            {
                var item = bSource.Current as BusinessCategory;
                ManufCatManipForm edit = new ManufCatManipForm(context, Entity.Category, item.CategoryId);
                edit.txtManufCat.Text = item.CategoryName;
                DialogResult res = edit.ShowDialog();

                if (res == DialogResult.OK)
                {
                    foreach (var c in dataCategory)
                    {
                        if (c.CategoryId == item.CategoryId)
                        {
                            c.CategoryName = edit.txtManufCat.Text;
                        }
                    }
                }
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bSource.Current is BusinessGood)
            {
                GoodManipForm add = new GoodManipForm(context);
                add.ShowDialog();
                RefreshDgv();
            }
            else if (bSource.Current is BusinessManufacturer)
            {
                ManufCatManipForm add = new ManufCatManipForm(context, Entity.Manufacturer);
                DialogResult res = add.ShowDialog();

                if (res == DialogResult.OK)
                {
                    dataManufacturer = DisplayManufacturers.GetManufacturers(context);
                    bSource.DataSource = dataManufacturer;
                }
            }
            else
            {
                ManufCatManipForm add = new ManufCatManipForm(context, Entity.Category);
                DialogResult res = add.ShowDialog();

                if (res == DialogResult.OK)
                {
                    dataCategory = DisplayCategory.GetCategories(context);
                    bSource.DataSource = dataCategory;
                }
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
            else if (bSource.Current is BusinessManufacturer)
            {
                BusinessManufacturer item = bSource.Current as BusinessManufacturer;
                DialogResult confirmDeletion = MessageBox.Show($"Are you sure you would like to delete {item.ManufacturerName}?", "Confirmation", MessageBoxButtons.YesNo);

                if (confirmDeletion == DialogResult.Yes)
                {
                    Manufacturer manuf = context.Manufacturers.Local
                    .Where(m => m.ManufacturerId == item.ManufacturerId)
                    .FirstOrDefault();

                    context.Manufacturers.Remove(manuf);
                    context.SaveChanges();
                    dataManufacturer = DisplayManufacturers.GetManufacturers(context);
                    bSource.DataSource = dataManufacturer;
                }
            }
            else
            {
                BusinessCategory item = bSource.Current as BusinessCategory;
                DialogResult confirmDeletion = MessageBox.Show($"Are you sure you would like to delete {item.CategoryName}?", "Confirmation", MessageBoxButtons.YesNo);

                if (confirmDeletion == DialogResult.Yes)
                {
                    Category category = context.Categories.Local
                    .Where(c => c.CategoryId == item.CategoryId)
                    .FirstOrDefault();

                    context.Categories.Remove(category);
                    context.SaveChanges();
                    dataCategory = DisplayCategory.GetCategories(context);
                    bSource.DataSource = dataCategory;
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
