using System;
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
    }
}
