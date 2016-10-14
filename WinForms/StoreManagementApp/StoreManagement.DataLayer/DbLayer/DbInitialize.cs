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

            User sa = new User {  }

            base.Seed(context);
        }
    }
}
