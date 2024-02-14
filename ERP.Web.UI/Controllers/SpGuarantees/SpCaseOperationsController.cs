using ERP.Authorization;
using ERP.Front.Helpers.Core;
using ERP.Web.UI.Models.ViewModels.SpGuarantees;
using ERP.WebUI.Controllers.Base;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ERP.Web.UI.Controllers.SpGuarantees
{
    public class SpCaseOperationsController : BaseController
    {
        public SpCaseOperationsController() : base("SpCaseOperations", string.Empty) { }

        // Default Operations : (TurnOff , Cancelation)
        public PartialViewResult Search() => PartialView();
        public PartialViewResult Data() => PartialView();
        public PartialViewResult Form() => PartialView();

        // Replace Operations
        public async Task<ActionResult> Replace()
        {
            var (allPermissions, insertPermission) = await GetMainPermissions("SpCaseOperationsReplace");

            TempData["Permissions"] = allPermissions;

            return View();
        }

        public async Task<ActionResult> FormView(string id)
        {
            try
            {
                var (allPermissions, insertPermission) = await GetMainPermissions("SpCaseOperationsReplace");

                TempData["Permissions"] = allPermissions;

                long longId = Convert.ToInt64(CipherStringController.Decrypt(id));

                var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/Get?Id={longId}", RestSharp.Method.GET);

                var data = Helper<SpCaseOperationsVM>.Convert(JsonConvert.SerializeObject(response.result));

                return View(data);
            }
            catch (Exception x)
            {
                TempData["Exc"] = x.InnerException?.Message ?? x.Message;
                return View();
            }
        }

        public PartialViewResult ReplaceSearch() => PartialView();
        public PartialViewResult ReplaceData() => PartialView();
        public PartialViewResult ReplaceForm(SpCaseOperationsVM vM) => PartialView(vM);



    }
}