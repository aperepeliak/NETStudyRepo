using IdentityFromScratch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentityFromScratch.Controllers
{
    [Authorize(Roles = SecurityRoles.Accounting)]
    public class AccountingController : Controller
    {
        // GET: Accounting
        public ActionResult Index()
        {
            return Content("Welcome to accounting");
        }
    }
}