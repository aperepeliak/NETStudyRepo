using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.DataLayer.DbLayer
{
    class DbInitialize: DropCreateDatabaseAlways<StoreContext>
    {
        protected override void Seed(StoreContext context)
        {
            Role superAdmin = new Role { RoleName = "superAdmin" };
            Role admin = new Role { RoleName = "admin" };
            Role cashier = new Role { RoleName = "cashier" };

            User sa = new User {    FirstName = "Super", LastName = "Admin",
                                    Login = "sa", Password = "super", Role = superAdmin };


            context.Roles.AddRange(new Role[] { superAdmin, admin, cashier });
            context.Users.Add(sa);

            base.Seed(context);
        }
    }
}
