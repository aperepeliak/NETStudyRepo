using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.DataLayer.DbLayer
{
    class StoreContext : DbContext
    {
        public StoreContext() : base("name=StoreManagement")
        {
            if (!Database.Exists())
            {
                Database.SetInitializer(new DbInitialize());
            }
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Good> Goods { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<SalesPos> SalesPos { get; set; }
        public DbSet<Sale> Sales { get; set; }

    }
}
