using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineStore.WebUI.Controllers
{
    public class GoodsController : Controller
    {

        // GET: Goods
        public ActionResult Index()
        {
            return View();
        }
    }
}