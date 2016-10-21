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
    public partial class ShowSales : Form
    {
        StoreContext context;
        BindingSource saleSource;
        BindingSource salePosSource;

        List<BusinessSale> sales;
        List<BusinessSalePos> salePos;

        public ShowSales(StoreContext context)
        {
            InitializeComponent();
            this.context = context;

            saleSource = new BindingSource();
            salePosSource = new BindingSource();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ShowSales_Load(object sender, EventArgs e)
        {
            context.Sales.Load();
            context.SalePos.Load();

            sales = DisplaySales.GetSales(context);

            saleSource.DataSource = sales;
            dgvSales.DataSource = saleSource;

            int currentId = (saleSource.Current as BusinessSale).SaleId;

            salePos = DisplaySalePos.GetSalePos(context, currentId);

            salePosSource.DataSource = salePos;
            dgvSalesPos.DataSource = salePosSource;
        }

        private void dgvSales_SelectionChanged(object sender, EventArgs e)
        {
            int currentId = (saleSource.Current as BusinessSale).SaleId;
            salePos = DisplaySalePos.GetSalePos(context, currentId);
            salePosSource.DataSource = salePos;
            dgvSalesPos.Refresh();
        }
    }
}
