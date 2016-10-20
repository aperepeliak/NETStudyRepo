using StoreDataLayer.DbLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static StoreWinForms.AdminForm;

namespace StoreWinForms
{
    public partial class ManufCatManipForm : Form
    {
        StoreContext context;
        int itemId;
        Entity item;

        public ManufCatManipForm(StoreContext context, Entity item, int itemId = 0)
        {
            InitializeComponent();
            this.context = context;
            this.item = item;
            this.itemId = itemId;

            lblManufCat.Text = item.ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (item == Entity.Manufacturer)
            {
                Manufacturer manuf;

                if (itemId != 0)
                {
                    manuf = context.Manufacturers.Local
                        .Where(m => m.ManufacturerId == itemId)
                        .FirstOrDefault();
                } else
                {
                    manuf = new Manufacturer();
                }

                manuf.ManufacturerName = txtManufCat.Text;
                

                if (itemId == 0)
                    context.Manufacturers.Add(manuf);

                context.SaveChanges();
                Close();
            }
            else
            {
                Category category;

                if (itemId != 0)
                {
                    category = context.Categories.Local
                        .Where(m => m.CategoryId == itemId)
                        .FirstOrDefault();
                }
                else
                {
                    category = new Category();
                }

                category.CategoryName = txtManufCat.Text;


                if (itemId == 0)
                    context.Categories.Add(category);

                context.SaveChanges();
                Close();
            }
        }
    }
}
