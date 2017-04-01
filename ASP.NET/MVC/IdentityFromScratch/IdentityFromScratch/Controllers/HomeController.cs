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
                var result = await SignInManager.PasswordSignInAsync
                    (user.UserName, password, true, false);

                if (result == SignInStatus.Success)
                {
                    return Content("Hello, " + user.FirstName + " " + user.LastName);
                }

                //user.FirstName = "Super";
                //user.LastName = "Admin";

                //await manager.UpdateAsync(user);
            }

            return Content("Hello, index.");
        }
    }
}