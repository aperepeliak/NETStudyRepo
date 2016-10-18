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
        int UserProfileId;
        public UsersCRUD(StoreContext context, int UserProfileId)
        {
            InitializeComponent();
            this.context = context;
            this.UserProfileId = UserProfileId;
        }

        private void UsersCRUD_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
