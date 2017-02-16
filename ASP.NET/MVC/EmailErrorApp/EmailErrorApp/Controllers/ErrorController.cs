using MyMessenger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmailErrorApp.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            using (var message = new Messenger())
            {
                message.SendErrorMessage
                    ("This is an error message from your ASP.NET MVC App.\nPlease ignore.",
                    "example@example.com");
            }

            throw new Exception("The message has been succesfully sent to your e-mail.");
        }
    }
}