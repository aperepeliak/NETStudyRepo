using BAL;
using BAL.Models;
using DAL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace IdentityExperiments.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController()
        {
            _unitOfWork = new UnitOfWork(new ApplicationDbContext());
        }

        // GET: Home
        public async Task<ActionResult> Index()
        {
            // var context = new IdentityDbContext<IdentityUser>(); //  looks for DefaultConnection
            var store = new UserStore<ApplicationUser>(_unitOfWork);
            var manager = new UserManager<ApplicationUser>(store); // use it to find, create users etc ...

            var email = "foo@bar.com";
            var password = "Passw0rd";
            var user = await manager.FindByEmailAsync(email);

            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = email,
                    Email = email,
                    FirstName = "Super",
                    LastName = "Admin"
                };

                await manager.CreateAsync(user, password);
            }
            else
            {
                user.FirstName = "Super";
                user.LastName = "Admin";

                await manager.UpdateAsync(user);
            }

            return Content("Hello");
        }
    }
}