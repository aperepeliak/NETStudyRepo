﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ShopDataLayer.DbLayer;
using ShopDataLayer.BusinessLayer;
using System.Data.Entity;

namespace Shop.WinForm
{
    public partial class MainForm : Form
    {

        ShopContext context = new ShopContext();

        BindingSource bsGoods = new BindingSource();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            context.Goods.Load();
            context.Manufacturers.Load();
            context.Categories.Load();

            List<GoodForDisplay> data = GoodsRepresentation.GetGoodForDisplay(context);

            bsGoods.DataSource = data;
            dgvGoods.DataSource = bsGoods;
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoodForDisplay item = bsGoods.Current as GoodForDisplay;

            FormManipData editGood = new FormManipData(context, item.GoodId);

            editGood.ShowDialog();
            RefreshDgv();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormManipData editGood = new FormManipData(context);

            editGood.ShowDialog();
            RefreshDgv();
        }

        private void RefreshDgv()
        {
            dgvGoods.DataSource = null;
            List<GoodForDisplay> data = GoodsRepresentation.GetGoodForDisplay(context);
            bsGoods.DataSource = data;
            dgvGoods.DataSource = bsGoods;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoodForDisplay item = bsGoods.Current as GoodForDisplay;
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
}
