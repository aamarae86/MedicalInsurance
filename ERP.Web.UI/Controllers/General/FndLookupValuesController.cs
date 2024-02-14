using ERP._System.__Settings._FndLookupValues.Dto;
using ERP.Authorization;
using ERP.Front.Helpers.Core;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Models.ResultModels;
using ERP.Web.UI.Models.ViewModels.General;
using ERP.WebUI.Controllers.Base;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using static ERP.Front.Helpers.Enums.Common;

namespace ERP.Web.UI.Controllers.General
{
    public class FndLookupValuesController : BaseController
    {
        public FndLookupValuesController() : base("FndLookupValues", PermissionNames.Pages_FndCollectors_Insert)
        { }

        public async override Task<ActionResult> Index() => View();

        public PartialViewResult FndLookupValuesSearch() => PartialView();
        public PartialViewResult FndLookupValuesData() => PartialView();

        public async Task<PartialViewResult> FndLookupValuesForm(long? id, string trigger)
        {
            if (id == null && trigger == FormTriggers.Insert.ToString())
            {
                ViewBag.trigger = trigger;

                return PartialView();
            }
            else if (id != null && trigger == FormTriggers.Update.ToString() || trigger == FormTriggers.Show.ToString())
            {
                var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/Get?Id={id}", RestSharp.Method.GET);

                var dataConverted = Helper<FndLookupValuesVM>.Convert(JsonConvert.SerializeObject(response.result));

                ViewBag.trigger = trigger;

                return PartialView(dataConverted);
            }

            return PartialView();
        }

        public async Task<ActionResult> LoadDataGrid(FndLookupValuesSearchDto searchParms)
        {
            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetAllWithSearch", RestSharp.Method.GET, searchParms.ToString());

            var dataConverted = Helper<IReadOnlyList<FndLookupValuesVM>>.Convert(JsonConvert.SerializeObject(response.result));

            return Json(dataConverted, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> PostFndLookupValues(FndLookupValuesVM vm)
        {
            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/Update", RestSharp.Method.PUT, vm);

            response.customRestResult = new CustomRestResult()
            {
                trigger = FormTriggers.Update.ToString(),
                message = response.success ? Settings.UpdatedSuccessfully : $"{Settings.Error} : {response.error.message}"
            };

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> GetAll()
        {
            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetAll", RestSharp.Method.GET);

            var dataConverted = Helper<ListResultBase<FndLookupValuesVM>>.Convert(JsonConvert.SerializeObject(response.result));

            return Json(dataConverted, JsonRequestBehavior.AllowGet);
        }

    }
}