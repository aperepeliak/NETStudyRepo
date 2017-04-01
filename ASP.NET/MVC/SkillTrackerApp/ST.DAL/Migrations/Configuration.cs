namespace ST.DAL.Migrations
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using ST.Core;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            context.Roles.AddOrUpdate(r => r.Name,
                new IdentityRole { Name = "admin" },
                new IdentityRole { Name = "manager" },
                new IdentityRole { Name = "developer" });

            context.Users.AddOrUpdate(u => u.UserName,
                new ApplicationUser
                { UserName = "Admin",
                  PasswordHash = "Passw0rd",
                });

            

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
