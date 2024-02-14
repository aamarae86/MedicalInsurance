using ERP.Core.Helpers.Extensions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Helpers.Middlewares
{
    public class AppLanguageMiddleware
    {
        private readonly RequestDelegate _next;
        public AppLanguageMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public Task Invoke(HttpContext httpContext)
        {
            _app.Reqlanguage = httpContext.Request.Query["ReqLang"].ToString();
            return _next(httpContext);
        }
    }

}
