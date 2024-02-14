using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Web.UI.Controllers.Base
{
    public class AnonymousBaseController : Controller
    {
        protected string BaseApiAuthUrL => $"{ConfigurationManager.AppSettings["ApiUrl"]}";

    }
}