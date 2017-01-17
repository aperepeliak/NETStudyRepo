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

                var behavior = host.Description.Behaviors.Find<ServiceBehaviorAttribute>();

                var chosenOption = groupBoxOptions.Controls.OfType<RadioButton>()
                                      .FirstOrDefault(r => r.Checked);

                switch (chosenOption.Text)
                {
                    case "Per Call":
                        behavior.InstanceContextMode = InstanceContextMode.PerCall;
                        break;

                    case "Per Session":
                        behavior.InstanceContextMode = InstanceContextMode.PerSession;
                        break;

                    case "Single":
                        behavior.InstanceContextMode = InstanceContextMode.Single;
                        break;
                }

                host.Open();
                btnSwitcher.Text = "Stop";
                lblStatus.Text = "Running...";
                lblStatus.ForeColor = Color.Green;
            }
            else
            {
                host.Close();
                btnSwitcher.Text = "Start";
                lblStatus.Text = "Stopped..";
                lblStatus.ForeColor = Color.Red;
            }
        }
    }
}
