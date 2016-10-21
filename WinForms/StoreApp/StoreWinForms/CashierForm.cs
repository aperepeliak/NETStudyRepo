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
        BindingSource cartSource;
        List<BusinessGood> dataGood;
        List<CartGood> sale;

        public CashierForm()
        {
            InitializeComponent();
            context = new StoreContext();
            bSource = new BindingSource();
            cartSource = new BindingSource();
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

            sale = new List<CartGood>();
            dataGood = DisplayGoods.GetGoods(context);

            bSource.DataSource = dataGood;
            dgvGoods.DataSource = bSource;

            cartSource.DataSource = sale;
            dgvCart.DataSource = cartSource;
        }

        private void dgvGoods_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            BusinessGood good = bSource.Current as BusinessGood;
            bool f = true;
            foreach (var item in sale)
            {
                if (item.GoodId == good.GoodId)
                {
                    item.Quantity++;
                    item.CartPosSum += good.Price;
                    f = false;
                    break;
                }
            }
            if (f)
                sale.Add(new CartGood { GoodId = good.GoodId, GoodName = good.GoodName, Quantity = 1, CartPosSum = good.Price });

            dgvCart.DataSource = null;
            cartSource.DataSource = sale;
            dgvCart.DataSource = cartSource;
        }
    }
}
