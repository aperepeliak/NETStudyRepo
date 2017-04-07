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

        private DataSet _db = new DataSet("Catalog");

        private SqlCommandBuilder _sqlCbProducts;
        private SqlCommandBuilder _sqlCbCategories;
        private SqlCommandBuilder _sqlCbSuppliers;

        private SqlDataAdapter _productsTableAdapter;
        private SqlDataAdapter _categoriesTableAdapter;
        private SqlDataAdapter _suppliersTableAdapter;

        private string _connectionString;

        public ProductContext()
        {
            _connectionString = ConfigurationManager
                               .ConnectionStrings["ProductContext"]
                               .ConnectionString;

            _productsTableAdapter   = new SqlDataAdapter("SELECT * FROM Products", _connectionString);
            _categoriesTableAdapter = new SqlDataAdapter("SELECT * FROM Categories", _connectionString);
            _suppliersTableAdapter  = new SqlDataAdapter("SELECT * FROM Suppliers", _connectionString);

            _sqlCbProducts   = new SqlCommandBuilder(_productsTableAdapter);
            _sqlCbCategories = new SqlCommandBuilder(_categoriesTableAdapter);
            _sqlCbSuppliers  = new SqlCommandBuilder(_suppliersTableAdapter);

            _productsTableAdapter   .Fill(_db, "Products");
            _categoriesTableAdapter .Fill(_db, "Categories");
            _suppliersTableAdapter  .Fill(_db, "Suppliers");

            BuildTableRelationship();

            Products    = _db.Tables["Products"]; 
            Categories  = _db.Tables["Categories"]; 
            Suppliers   = _db.Tables["Suppliers"];
        }

        public void SaveChanges()
        {
            _productsTableAdapter   .Update(_db, "Products");
            _categoriesTableAdapter .Update(_db, "Categories");
            _suppliersTableAdapter  .Update(_db, "Suppliers");
        }

        public DataRow GetParentRowFor(DataRow row, string relationName)
        {
            return row.GetParentRow(_db.Relations[relationName]);                    
        }

        public DataRow[] GetChildRowsFor(DataRow row, string relationName)
        {
            return row.GetChildRows(_db.Relations[relationName]);
        }

        private void BuildTableRelationship()
        {
            _db.Relations.AddRange(new[]
            {
                new DataRelation("CategoryProduct",
                _db.Tables["Categories"].Columns["Id"],
                _db.Tables["Products"].Columns["CategoryId"]),

                new DataRelation("SupplierProduct",
                _db.Tables["Suppliers"].Columns["Id"],
                _db.Tables["Products"].Columns["SupplierId"])
            });
        }
    }
}
