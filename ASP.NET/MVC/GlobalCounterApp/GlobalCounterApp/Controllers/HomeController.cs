using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GlobalCounterApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About(string name = "Andrew")
        {
            ViewBag.Name = name ?? "Petya";
            return View();
        }
    }
}