using ProductsServiceClient.ProductsServiceReference;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductsServiceClient
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            var client = new ProductContractClient("NetNamedPipeBinding_IProductContract",
                "net.pipe://localhost/");
            try
            {
                Product[] products = client.GetAll();
                var hash = client.GetServiceHash();
                dgvResult.DataSource = products;

                string info =
                    $"Host hashcode : {hash}\nSession ID : {client.InnerChannel.SessionId}\n";

                MessageBox.Show(info);
            }
            catch (EndpointNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
