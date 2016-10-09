using ShopDataLayer.DbLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shop.WinForm
{
    public partial class FormManipData : Form
    {

        ShopContext context;
        public int GoodId { get; set; }

        public FormManipData(ShopContext context, int goodId)
        {
            InitializeComponent();
            this.context = context;
            this.GoodId = goodId;
        }

        private void FormManipData_Load(object sender, EventArgs e)
        {
            Good good = context.Goods.Local
                .Where(g => g.GoodId == GoodId)
                .FirstOrDefault();

            txtGoodName.Text = good.GoodName;

            cmbManuf.DisplayMember = "ManufacturerName";
            cmbManuf.ValueMember = "ManufacturerId";
            cmbManuf.DataSource = context.Manufacturers.Local;
            cmbManuf.SelectedValue = good.ManufacturerId;
        }
    }
}
