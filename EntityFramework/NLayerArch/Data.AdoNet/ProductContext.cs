using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Data.AdoNet
{
    public class ProductContext
    {
        public DataTable Products   { get; }
        public DataTable Categories { get; }
        public DataTable Suppliers  { get; }

        private DataSet _context = new DataSet("Catalog");

        private SqlCommandBuilder _sqlCbProducts;
        private SqlCommandBuilder _sqlCbCategories;
        private SqlCommandBuilder _sqlCbSuppliers;

        private SqlDataAdapter _productsTableAdapter;
        private SqlDataAdapter _categoriesTableAdapter;
        private SqlDataAdapter _suppliersTableAdapter;

        string _connectionString;

        public ProductContext()
        {
            _connectionString = ConfigurationManager
                               .ConnectionStrings["ProductContext"]
                               .ConnectionString;

            _productsTableAdapter   = new SqlDataAdapter("Select * from Products", _connectionString);
            _categoriesTableAdapter = new SqlDataAdapter("Select * from Categories", _connectionString);
            _suppliersTableAdapter  = new SqlDataAdapter("Select * from Suppliers", _connectionString);

            _sqlCbProducts   = new SqlCommandBuilder(_productsTableAdapter);
            _sqlCbCategories = new SqlCommandBuilder(_categoriesTableAdapter);
            _sqlCbSuppliers  = new SqlCommandBuilder(_suppliersTableAdapter);

            _productsTableAdapter   .Fill(_context, "Products");
            _categoriesTableAdapter .Fill(_context, "Categories");
            _suppliersTableAdapter  .Fill(_context, "Suppliers");

            Products    = _context.Tables["Products"]; 
            Categories  = _context.Tables["Categories"]; 
            Suppliers   = _context.Tables["Suppliers"];
        }

        public void SaveChanges()
        {
            _productsTableAdapter   .Update(_context, "Products");
            _categoriesTableAdapter .Update(_context, "Categories");
            _suppliersTableAdapter  .Update(_context, "Suppliers");
        }
    }
}
