using Abp.Authorization;
using ERP.Front.Helpers.Core;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ERP.WebUI.Controllers.Base
{
    public class CustomActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpSessionStateBase session = filterContext.HttpContext.Session;

            if (session["userId"] == null || session["token"] == null)
            {
                StringBuilder queryString = new StringBuilder();
                foreach (var param in filterContext.ActionParameters)
                {
                    queryString.Append($"{param.Key}=");
                    queryString.Append($"{param.Value}&");
                }
                string redirectController = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
                string redirectAction = filterContext.ActionDescriptor.ActionName;

                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                        { "Controller", "Login" },
                        { "Action", "Index" },
                        {"Area" , string.Empty },
                        {"returnUrl", $"{redirectController}/{redirectAction}?{queryString.ToString()}" }
                    });
            }
        }
    }
}