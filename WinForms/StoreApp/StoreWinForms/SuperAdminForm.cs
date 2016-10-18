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
    public partial class SuperAdminForm : Form
    {
        StoreContext context;
        BindingSource bSource;

        public SuperAdminForm(StoreContext context)
        {
            InitializeComponent();
            this.context = context;
            bSource = new BindingSource();
        }

        private void SuperAdminForm_Load(object sender, EventArgs e)
        {
            context.Roles.Load();

            List<User> data = DisplayUsers.GetUsers(context);

            bSource.DataSource = data;
            dgvSuper.DataSource = bSource;
        }

        private void editUserToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnSAExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
