using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;
using ProductsServiceLib;


namespace ProductsServiceHost
{
    public partial class Server : Form
    {
        ServiceHost host;
        public Server()
        {
            InitializeComponent();     
        }

        private void btnSwitcher_Click(object sender, EventArgs e)
        {
            if (btnSwitcher.Text == "Start")
            {
                host = new ServiceHost(typeof(ProductContract));
                host.Open();
                btnSwitcher.Text = "Stop";
                lblStatus.Text = "Running...";
                lblStatus.ForeColor = Color.Green;
            } else
            {
                host.Close();
                btnSwitcher.Text = "Start";
                lblStatus.Text = "Stopped..";
                lblStatus.ForeColor = Color.Red;
            }          
        }
    }
}
