using Microsoft.AspNetCore.Antiforgery;
using ERP.Controllers;

namespace ERP.Web.Host.Controllers
{
    public class AntiForgeryController : ERPControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
