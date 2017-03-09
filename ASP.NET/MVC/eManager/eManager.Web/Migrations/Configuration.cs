namespace eManager.Web.Migrations
{
    using Domain;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Security;

    internal sealed class Configuration : DbMigrationsConfiguration<eManager.Web.Infrastructure.DepartmentDb>
    {
        public Configuration() { AutomaticMigrationsEnabled = true; }

        protected override void Seed(eManager.Web.Infrastructure.DepartmentDb context)
        {
            context.Departments.AddOrUpdate(d => d.Name,
                new Department { Name = "Engineering" },
                new Department { Name = "Sales" },
                new Department { Name = "Shipping" },
                new Department { Name = "Human Resource" }
                );

            //if (Roles.RoleExists("Admin"))
            //{
            //    Roles.CreateRole("Admin");
            //}

            //if (Membership.GetUser("sa") == null)
            //{
            //    Membership.CreateUser("sa", "qwerty123456");
            //    Roles.AddUserToRole("sa", "Admin");
            //}
        }
    }
}
