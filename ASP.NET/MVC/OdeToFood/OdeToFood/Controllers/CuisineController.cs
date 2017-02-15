using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Controllers
{
    // [Authorize]
    public class CuisineController : Controller
    {        
        public ActionResult Search(string name = "french")
        {
            throw new Exception("Error!");
            //var message = Server.HtmlEncode(name);
            //return Content(message);
        }
    }
}