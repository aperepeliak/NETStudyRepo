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
        List<User> data;

        public SuperAdminForm(StoreContext context)
        {
            InitializeComponent();
            this.context = context;
            bSource = new BindingSource();
        }

        private void SuperAdminForm_Load(object sender, EventArgs e)
        {
            context.Roles.Load();

            data = DisplayUsers.GetUsers(context);

            bSource.DataSource = data;
            dgvSuper.DataSource = bSource;
        }

        private void editUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            User current = bSource.Current as User;

            UsersCRUD editUserProfile = new UsersCRUD(context, current.UserId);
            DialogResult res = editUserProfile.ShowDialog();

            if (res == DialogResult.OK)
            {
                foreach (var item in data)
                {
                    if (item.UserId == current.UserId)
                    {
                        item.UserFirstName = 
                    }
                }
            }
        }

        private void btnSAExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
