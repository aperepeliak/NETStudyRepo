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
            context.UserProfiles.Load();


        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
