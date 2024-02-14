using ERP._System._AffliateAccount.Dto;
using ERP.Front.Helpers.Core;
using ERP.Front.Helpers.Repository;
using ERP.MultiTenancy.Dto;
using ERP.Web.UI.Models.ViewModels.Tenant;
using ERP.WebUI.Models;
using Newtonsoft.Json;
using System.Configuration;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ERP.Web.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index() => View();

        public ActionResult AffliateAccount() => View();

        public ActionResult Registration() => View();

        public PartialViewResult ScPortalRequestsData() => PartialView();

        [HttpPost]
        public async Task<ActionResult> Registration(CreateTenantVM tenantDto)
        {
            RestClientContainer restClientContainer = new RestClientContainer($"{ConfigurationManager.AppSettings["ApiUrl"]}services/app/");

            var response = await restClientContainer.SendRequest<RestResult>($"Tenant/Create", RestSharp.Method.POST, tenantDto);

            if (response.success)
            {
                var data = Helper<AuthToken>.Convert(JsonConvert.SerializeObject(response.result));

                return Redirect($"{HttpContext.Request.Url.Scheme}://{tenantDto.TenancyName}.tenxerp.com"); // RedirectToAction("Index", "Login");
            }
            else
            {
                TempData["FailedMessage"] = $"{response.error.message}";
                return RedirectToAction(nameof(Registration));
            }
        }

        [HttpPost]
        public async Task<ActionResult> AffliateAccount(AffliateAccountDto affliateAccountDto)
        {
            RestClientContainer restClientContainer = new RestClientContainer($"{ConfigurationManager.AppSettings["ApiUrl"]}services/app/");

            var response = await restClientContainer.SendRequest<RestResult>($"AffliateAccount/Create", RestSharp.Method.POST, affliateAccountDto);

            if (response.success)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                TempData["FailedMessage"] = $"{response.error.message}";

                return RedirectToAction(nameof(AffliateAccount));
            }
        }
    }
}