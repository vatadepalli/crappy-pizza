using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using BOL;

namespace StoreApp {
    public class MvcApplication : System.Web.HttpApplication {
        protected void Application_Start() {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Session_Start() {
            HttpContext.Current.Session["user"] = null;
            HttpContext.Current.Session["cart"] = new List<Pizza>();
        }

        protected void Session_End() {
            HttpContext.Current.Session.Abandon();
        }

    }
}
