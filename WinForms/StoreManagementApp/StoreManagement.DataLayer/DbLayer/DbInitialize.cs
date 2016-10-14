using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.DataLayer.DbLayer
{
    public class DbInitialize: DropCreateDatabaseAlways<StoreContext>
    {
        protected override void Seed(StoreContext context)
        {
            Role superAdmin = new Role { RoleName = "superAdmin" };
            Role admin = new Role { RoleName = "admin" };
            Role cashier = new Role { RoleName = "cashier" };

            User sa = new User {    FirstName = "Super", LastName = "Admin",
                                    Login = "sa", Password = "super", Role = superAdmin };

            User u1 = new User {    FirstName = "Fedor", LastName = "Ivanov",
                                    Login = "Fedor", Password = "Ivanov", Role = cashier };




            context.Roles.AddRange(new Role[] { superAdmin, admin, cashier });
            context.Users.Add(sa);
            context.Users.Add(u1);

            Category tires = new Category { CategoryName = "Tires" };
            context.Categories.Add(tires);

            Manufacturer yoko = new Manufacturer { ManufacturerName = "Yokohama" };
            Manufacturer bridge = new Manufacturer { ManufacturerName = "Bridgestone" };
            Manufacturer nokian = new Manufacturer { ManufacturerName = "Nokian" };
            context.Manufacturers.AddRange(new Manufacturer[] { yoko, bridge, nokian });

            Good yoko1 = new Good { GoodName = "Yoko tr-1", Manufacturer = yoko, Category = tires, Price = 200 };
            Good bridge1 = new Good { GoodName = "Br18R", Manufacturer = bridge, Category = tires, Price = 150 };
            Good bridge2 = new Good { GoodName = "BR16R", Manufacturer = bridge, Category = tires, Price = 120 };
            context.Goods.AddRange(new Good[] { yoko1, bridge1, bridge2 });

            List<Good> firstSale = new List<Good> { yoko1, bridge1, bridge2 };

            SalePos salePos1 = new SalePos { Goods = firstSale };
            context.SalesPos.Add(salePos1);

            Sale sale1 = new Sale { User = u1, SaleDate = DateTime.Now, SalePos = salePos1 };
            context.Sales.Add(sale1);

            base.Seed(context);
        }
    }
}
