using ERP.Core.Helpers.Extensions;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ERP.CustomFilters
{
    public class AppLanguageFilter : ActionFilterAttribute
    {
        public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!string.IsNullOrEmpty(context.HttpContext.Request.Query["ReqLang"].ToString()))
            {
             _app.Reqlanguage = context.HttpContext.Request.Query["ReqLang"].ToString();
            }
            var currentLang = Thread.CurrentThread.CurrentUICulture.Name;
            return base.OnActionExecutionAsync(context, next);
        }

    }
}
