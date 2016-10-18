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

            editUserProfile.ShowDialog();
            RefreshDgv();
        }


        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsersCRUD addUserProfile = new UsersCRUD(context);

            addUserProfile.ShowDialog();
            RefreshDgv();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            User current = bSource.Current as User;
            if (current.RoleName == "SuperAdmin")
            {
                MessageBox.Show("You are not allowed to delete superAdmin!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                DialogResult confirmDeletion = MessageBox.Show($"Are you sure you would like to delete {current.UserFirstName} {current.UserLastName}?",
                                                "Confirmation", MessageBoxButtons.YesNo);

                if (confirmDeletion == DialogResult.Yes)
                {
                    UserProfile user = context.UserProfiles.Local
                    .Where(u => u.UserId == current.UserId)
                    .FirstOrDefault();

                    context.UserProfiles.Remove(user);
                    context.SaveChanges();
                    RefreshDgv();
                }
            }
        }

        private void btnSAExit_Click(object sender, EventArgs e)
        {
            context.SaveChanges();
            Close();
        }

        private void RefreshDgv()
        {
            dgvSuper.DataSource = null;
            data = DisplayUsers.GetUsers(context);
            bSource.DataSource = data;
            dgvSuper.DataSource = bSource;
        }


    }
}
