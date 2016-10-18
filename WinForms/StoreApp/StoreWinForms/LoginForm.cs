using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using StoreDataLayer.DbLayer;
using System.Data.Entity;

namespace StoreWinForms
{
    public partial class LoginForm : Form
    {
        StoreContext context;

        public LoginForm()
        {
            InitializeComponent();
            context = new StoreContext();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // (SA, student) - for super admin
            if (context.UserProfiles.Local.Any(u => (u.UserLogin == tbxLogin.Text) &&
                                                    (u.UserPassword == tbxPassword.Text)))
            {
                UserProfile activeUser = context.UserProfiles.Local
                                            .Where(u => (u.UserLogin == tbxLogin.Text) &&
                                                        (u.UserPassword == tbxPassword.Text))
                                            .First();

                Hide();
                switch (activeUser.RoleId)
                {
                    case 1:
                        // super admin
                        SuperAdminForm saForm = new SuperAdminForm(context);
                        saForm.ShowDialog();
                        break;

                    case 2:
                        // admin
                        AdminForm aForm = new AdminForm();
                        aForm.ShowDialog();
                        break;

                    case 3:
                        // cashier

                        break;
                }

                Close();

            }
            else
            {
                MessageBox.Show("Wrong login or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            context.UserProfiles.Load();
        }
    }
}
