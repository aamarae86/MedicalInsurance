using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ERP.Web.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["Lang"];
            if (cookie != null && cookie.Value != null && cookie.Value.ToString().Trim() != string.Empty)
            {
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cookie.Value);
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(cookie.Value);
            }
            else
            {
                HttpCookie cookie1 = new HttpCookie("Lang")
                {
                    Value = "ar-EG",
                    Expires = DateTime.Now.AddDays(90)
                };
                Response.Cookies.Add(cookie1);
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("ar-EG");
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ar-EG");
            }
        }
    }
}
