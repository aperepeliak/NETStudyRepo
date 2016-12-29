using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.Configuration;

namespace _005_MultitabledDS_GUI
{
    public partial class MainForm : Form
    {
        private DataSet _autoLot = new DataSet("AutoLot");

        private SqlCommandBuilder _sqlCbInventory;
        private SqlCommandBuilder _sqlCbCustomers;
        private SqlCommandBuilder _sqlCbOrders;

        private SqlDataAdapter _invTableAdapter;
        private SqlDataAdapter _custTableAdapter;
        private SqlDataAdapter _ordersTableAdapter;

        private string _cnStr;

        public MainForm()
        {
            InitializeComponent();

            _cnStr =
                ConfigurationManager.ConnectionStrings["AutoLotSqlProvider"]
                .ConnectionString;

            _invTableAdapter = new SqlDataAdapter("Select * from Inventory", _cnStr);
            _custTableAdapter = new SqlDataAdapter("Select * from Customers", _cnStr);
            _ordersTableAdapter = new SqlDataAdapter("Select * from Orders", _cnStr);

            _sqlCbInventory = new SqlCommandBuilder(_invTableAdapter);
            _sqlCbCustomers = new SqlCommandBuilder(_custTableAdapter);
            _sqlCbOrders = new SqlCommandBuilder(_ordersTableAdapter);

            _invTableAdapter.Fill(_autoLot, "Inventory");
            _custTableAdapter.Fill(_autoLot, "Customers");
            _ordersTableAdapter.Fill(_autoLot, "Orders");

            BuildTableRelationship();

            dgvInv.DataSource = _autoLot.Tables["Inventory"];
            dgvCustomers.DataSource = _autoLot.Tables["Customers"];
            dgvOrders.DataSource = _autoLot.Tables["Orders"];
        }

        private void BuildTableRelationship()
        {
            // CustomerOrder data relation object
            var dr = new DataRelation("CustomerOrder",
                _autoLot.Tables["Customers"].Columns["CustID"],
                _autoLot.Tables["Orders"].Columns["CustID"]);

            _autoLot.Relations.Add(dr);

            // InventoryOrder relations
            dr = new DataRelation("InventoryOrder",
                _autoLot.Tables["Inventory"].Columns["CarID"],
                _autoLot.Tables["Orders"].Columns["CarID"]);

            _autoLot.Relations.Add(dr);
        }

        private void btnUpdDB_Click(object sender, EventArgs e)
        {
            try
            {
                _invTableAdapter.Update(_autoLot, "Inventory");
                _custTableAdapter.Update(_autoLot, "Customers");
                _ordersTableAdapter.Update(_autoLot, "Orders");
            }
            catch (Exception)
            {
                MessageBox.Show("Sorry, smth went wrong ...");
            }
        }

        private void btnOrderDetails_Click(object sender, EventArgs e)
        {
            string orderInfo = string.Empty;
            int custID = int.Parse(txtCustID.Text);

            var drsCust = _autoLot.Tables["Customers"].Select($"CustID = {custID}");

            orderInfo +=
                $"Customer {drsCust[0]["CustID"]}: {drsCust[0]["FirstName"].ToString().Trim()} {drsCust[0]["LastName"].ToString().Trim()}\n";

            var drsOrder = drsCust[0].GetChildRows(_autoLot.Relations["CustomerOrder"]);

            // Loop through all orders for this customer
            foreach (DataRow order in drsOrder)
            {
                orderInfo += $"----\nOrder Number: {order["OrderID"]}\n";

                // Get the car referenced by this order
                DataRow[] drsInv = order.GetParentRows(_autoLot.Relations["InventoryOrder"]);

                // Get car info for this order
                DataRow car = drsInv[0];
                orderInfo += $"Make: {car["Make"]}\n";
                orderInfo += $"Color: {car["Color"]}\n";
                orderInfo += $"PetName: {car["PetName"]}\n";
            }
            MessageBox.Show(orderInfo, "Order Details");
        }
    }
}
