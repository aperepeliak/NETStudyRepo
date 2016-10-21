using StoreDataLayer.BusinessLayer;
using StoreDataLayer.DbLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreWinForms
{
    public partial class CashierForm : Form
    {
        UserProfile activeUser;
        StoreContext context;
        BindingSource bSource;
        BindingSource cartSource;
        List<BusinessGood> dataGood;
        BindingList<CartGood> sale;

        public CashierForm(UserProfile activeUser)
        {
            InitializeComponent();
            context = new StoreContext();
            bSource = new BindingSource();
            cartSource = new BindingSource();
            this.activeUser = activeUser;
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

            sale = new BindingList<CartGood>();
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

            dgvCart.Refresh();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            sale = null;
            sale = new BindingList<CartGood>();
            dgvCart.DataSource = sale;

        }

        // Complete Sale button
        private void button3_Click(object sender, EventArgs e)
        {
            if (sale.Count != 0)
            {
                var tran = context.Database.BeginTransaction(IsolationLevel.ReadCommitted);
                try
                {
                    Sale newSale = new Sale()
                    {
                        SaleDate = DateTime.Now,
                        SaleNumber = Guid.NewGuid().ToString().Substring(0, 23),
                        UserId = activeUser.UserId,
                        SaleAmount = 0
                    };

                    context.Sales.Add(newSale);
                    context.SaveChanges();

                    foreach (var item in sale)
                    {
                        object[] parDetail = new object[] {
                            new SqlParameter("@SaleId", newSale.SaleId),
                            new SqlParameter("@GoodId", item.GoodId),
                            new SqlParameter("@Quantity", item.Quantity),
                            };

                        context.Database.ExecuteSqlCommand("exec [dbo].[InsertSalePos] @SaleId, @GoodId, @Quantity",
                            parDetail);
                    }
                    tran.Commit();

                    sale = null;
                    sale = new BindingList<CartGood>();
                    dgvCart.DataSource = sale;
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                    tran.Rollback();
                }
            }
        }

        private void btnShowSales_Click(object sender, EventArgs e)
        {
            ShowSales showSales = new ShowSales(context);
            showSales.ShowDialog();
        }
    }
}
