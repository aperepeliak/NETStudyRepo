namespace Data.EF
{
    using Data.EF.EntityConfigs;
    using DomainLayer.Models;
    using System.Data.Entity;

    public class ProductContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        public ProductContext()
            : base("name=ProductContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductConfig());
            modelBuilder.Configurations.Add(new CategoryConfig());
            modelBuilder.Configurations.Add(new SupplierConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}