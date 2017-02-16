using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GlobalCounterApp.Controllers
{
    public class CounterController : Controller
    {
        // GET: Counter
        public ActionResult Index()
        {
            ViewBag.Counter = MvcApplication.Counter;
            return View();
        }
    }
}