﻿using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;

namespace IdentityFromScratch.Controllers
{
    public abstract class BaseController : Controller
    {
        public ApplicationUserManager UserManager
        {
            get { return HttpContext.GetOwinContext().Get<ApplicationUserManager>(); }
        }

        public ApplicationSignInManager SignInManager
        {
            get { return HttpContext.GetOwinContext().Get<ApplicationSignInManager>(); }
        }
    }
}