namespace StoreDataLayer.DbLayer
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class StoreContext : DbContext
    {
        public StoreContext()
            : base("name=StoreContext")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Good> Goods { get; set; }
        public virtual DbSet<Manufacturer> Manufacturers { get; set; }
        public virtual DbSet<Photo> Photos { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<SalePos> SalePos { get; set; }
        public virtual DbSet<UserProfile> UserProfiles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Good>()
                .Property(e => e.GoodName)
                .IsUnicode(false);

            modelBuilder.Entity<Good>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Good>()
                .Property(e => e.Stock)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Sale>()
                .Property(e => e.SaleAmount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SalePos>()
                .Property(e => e.Quantity)
                .HasPrecision(18, 3);

            modelBuilder.Entity<SalePos>()
                .Property(e => e.SalePosSum)
                .HasPrecision(19, 4);
        }
    }
}
