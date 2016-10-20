﻿using StoreDataLayer.DbLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreWinForms
{
    public partial class GoodManipForm : Form
    {
        StoreContext context;
        public int GoodId { get; set; }

        public GoodManipForm(StoreContext context, int goodId = 0)
        {
            InitializeComponent();
            this.context = context;
            this.GoodId = goodId;
        }

        private void GoodManipForm_Load(object sender, EventArgs e)
        {
            if (GoodId != 0)
            {
                Good good = context.Goods.Local
                .Where(g => g.GoodId == GoodId)
                .FirstOrDefault();

                txtGoodName.Text = good.GoodName;
                txtPrice.Text = good.Price.ToString();
                txtStock.Text = good.Stock.ToString();


                cmbManuf.DisplayMember = "ManufacturerName";
                cmbManuf.ValueMember = "ManufacturerId";
                cmbManuf.DataSource = context.Manufacturers.Local;
                cmbManuf.SelectedValue = good.ManufacturerId;

                cmbCat.DisplayMember = "CategoryName";
                cmbCat.ValueMember = "CategoryId";
                cmbCat.DataSource = context.Categories.Local;
                cmbCat.SelectedValue = good.CategoryId;
            }
            else
            {
                cmbManuf.DisplayMember = "ManufacturerName";
                cmbManuf.ValueMember = "ManufacturerId";
                cmbManuf.DataSource = context.Manufacturers.Local;

                cmbCat.DisplayMember = "CategoryName";
                cmbCat.ValueMember = "CategoryId";
                cmbCat.DataSource = context.Categories.Local;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Good good;

            if (GoodId != 0)
            {
                good = context.Goods.Local
                .Where(g => g.GoodId == GoodId)
                .FirstOrDefault();
            }
            else
            {
                good = new Good();
            }

            good.GoodName = txtGoodName.Text;
            good.ManufacturerId = (int)cmbManuf.SelectedValue;
            good.CategoryId = (int)cmbCat.SelectedValue;
            good.Price = Convert.ToDecimal(txtPrice.Text);
            good.Stock = Convert.ToDecimal(txtStock.Text);

            if (GoodId == 0)
                context.Goods.Add(good);

            context.SaveChanges();

            Close();
        }
    }
}
