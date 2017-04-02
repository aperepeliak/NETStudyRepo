using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ST.WebUI.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Categories()
        {
            return Content("Categories");
        }

        public ActionResult Skills()
        {
            return Content("Skills");
        }

        public ActionResult Developers()
        {
            return Content("Developers");
        }

        public ActionResult Managers()
        {
            return Content("Managers");
        }
    }
}