using IdentityFromScratch.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace IdentityFromScratch.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public async Task<ActionResult> Index()
        {
            #region notNeededAnymore
            //var context = new ApplicationDbContext(); //  looks for DefaultConnection
            //var store = new UserStore<CustomUser>(context);
            //var manager = new UserManager<CustomUser>(store); // use it to find, create users etc ...

            //var signInManager = new SignInManager<CustomUser, string>
            //    (manager, HttpContext.GetOwinContext().Authentication);
            #endregion



            var email = "foo@bar.com";
            var password = "Passw0rd";
            var user = await UserManager.FindByEmailAsync(email);

            var roles = ApplicationRoleManager.Create(HttpContext.GetOwinContext());

            if (!await roles.RoleExistsAsync(SecurityRoles.Admin))
            {
                await roles.CreateAsync(new IdentityRole { Name = SecurityRoles.Admin });
            }

            if (!await roles.RoleExistsAsync(SecurityRoles.IT))
            {
                await roles.CreateAsync(new IdentityRole { Name = SecurityRoles.IT });
            }

            if (!await roles.RoleExistsAsync(SecurityRoles.Accounting))
            {
                await roles.CreateAsync(new IdentityRole { Name = SecurityRoles.Accounting });
            }

            if (user == null)
            {
                user = new CustomUser
                {
                    UserName = email,
                    Email = email,
                    FirstName = "Super",
                    LastName = "Admin"
                };

                await UserManager.CreateAsync(user, password);
            }
            else
            {
                // await UserManager.AddToRoleAsync(user.Id, SecurityRoles.Admin);

                //var result = await SignInManager.PasswordSignInAsync
                //    (user.UserName, password, true, false);

                //if (result == SignInStatus.Success)
                //{
                //    return Content("Hello, " + user.FirstName + " " + user.LastName);
                //}

                //user.FirstName = "Super";
                //user.LastName = "Admin";

                //await manager.UpdateAsync(user);
            }

            return Content("Hello, index.");
        }

        public async Task<ActionResult> Login()
        {
            var email = "foo@bar.com";
            var user = await UserManager.FindByEmailAsync(email);
            await SignInManager.SignInAsync(user, true, true);

            return RedirectToAction("Index");
        }

        public ActionResult Logout()
        {
            HttpContext.GetOwinContext().Authentication.SignOut();

            return RedirectToAction("Index");
        }
    }
}