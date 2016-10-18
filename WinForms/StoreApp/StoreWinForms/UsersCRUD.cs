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

namespace StoreWinForms
{
    public partial class UsersCRUD : Form
    {
        StoreContext context;
        public int UserProfileId { get; set; }

        public UsersCRUD(StoreContext context, int UserProfileId = 0)
        {
            InitializeComponent();
            this.context = context;
            this.UserProfileId = UserProfileId;
        }

        private void UsersCRUD_Load(object sender, EventArgs e)
        {
            if (UserProfileId != 0)
            {
                UserProfile cur = context.UserProfiles.Local
                    .Where(u => u.UserId == UserProfileId)
                    .FirstOrDefault();

                tbxFirstName.Text = cur.UserFirstName;
                tbxLastName.Text = cur.UserLastName;
                tbxLogin.Text = cur.UserLogin;
                tbxPassword.Text = cur.UserPassword;

                cmbRole.DisplayMember = "RoleName";
                cmbRole.ValueMember = "RoleId";
                cmbRole.DataSource = context.Roles.Local;
                cmbRole.SelectedValue = cur.RoleId;
            }
            else
            {
                cmbRole.DisplayMember = "RoleName";
                cmbRole.ValueMember = "RoleId";
                cmbRole.DataSource = context.Roles.Local;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            UserProfile user;

            if (UserProfileId != 0)
            {
                user = context.UserProfiles.Local
                    .Where(u => u.UserId == UserProfileId)
                    .FirstOrDefault();
            }
            else
            {
                user = new UserProfile();
            }

            user.UserFirstName = tbxFirstName.Text;
            user.UserLastName = tbxLastName.Text;
            user.UserLogin = tbxLogin.Text;
            user.UserPassword = tbxPassword.Text;
            user.RoleId = (int)cmbRole.SelectedValue;

            if (UserProfileId == 0)
                context.UserProfiles.Add(user);

            context.SaveChanges();
            Close();
        }
    }
}
