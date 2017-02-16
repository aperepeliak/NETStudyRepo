using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GlobalCounterApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static int Counter = 0;
      
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);            
        }

        protected void Application_BeginRequest()
        {
            Counter++;
        }
    }
}
