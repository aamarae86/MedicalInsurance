using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ERP.WebUI.Controllers.Base
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class CustomPermissionFilter : ActionFilterAttribute
    {
        /// <summary>
        /// A permission to authorize.
        /// </summary>
        public string Permission { get; }

        /// <summary>
        /// If this property is set to true, all of the <see cref="Permission"/> must be granted.
        /// If it's false, at least one of the <see cref="Permission"/> must be granted.
        /// Default: false.
        /// </summary>
        public bool RequireAllPermissions { get; set; }

        /// <summary>
        /// Creates a new instance of <see cref="CustomPermissionFilter"/> class.
        /// </summary>
        /// <param name="permissions">A permissions to authorize</param>
        public CustomPermissionFilter(string permission)
        {
            Permission = permission;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpSessionStateBase session = filterContext.HttpContext.Session;
            
            string perms = session["UserMenuPermissions"]?.ToString();
            
            if (perms == null || !perms.Contains($"{Permission},"))
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                        { "Controller", "Home" },
                        { "Action", "Index" },
                        {"Area" , string.Empty }
                    });
            }
            base.OnActionExecuting(filterContext);
        }
    }

}