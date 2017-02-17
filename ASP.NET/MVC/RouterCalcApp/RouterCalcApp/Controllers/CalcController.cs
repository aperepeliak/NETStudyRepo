using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RouterCalcApp.Controllers
{
    public class CalcController : Controller
    {
        // GET: Calc
        public ActionResult Add(int x, int y)
        {
            ViewBag.X = x;
            ViewBag.Y = y;

            return View();
        }

        public ActionResult Sub(int x, int y)
        {
            ViewBag.X = x;
            ViewBag.Y = y;

            return View();
        }

        public ActionResult Mul(int x, int y)
        {
            ViewBag.X = x;
            ViewBag.Y = y;

            return View();
        }

        public ActionResult Div(int x, int y)
        {
            ViewBag.X = x;
            ViewBag.Y = y;

            return View();
        }
    }
}