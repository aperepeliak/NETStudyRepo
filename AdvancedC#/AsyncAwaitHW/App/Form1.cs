using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnGetEmp_Click(object sender, EventArgs e)
        {
            dgvEmployees.DataSource = await Task.Run(() => DataLayer.GetEmployee());
        }
    }
}
