using ERP.Authorization;
using ERP.Front.Helpers.Core;
using ERP.Front.Helpers.DataTableHelpers;
using ERP.Front.Helpers.Parameters;
using ERP.Helpers.Parameters.GlMainAccounts;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Models.ResultModels;
using ERP.Web.UI.Models.ViewModels.Accounts;
using ERP.WebUI.Controllers.Base;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using static ERP.Front.Helpers.Enums.Common;

namespace ERP.Web.UI.Controllers.Accounts
{
    public class GlMainAccountsController : BaseController
    {
        public GlMainAccountsController() : base("GlMainAccounts", PermissionNames.Pages_GlMainAccounts_Insert) { }

        public PartialViewResult GlMainAccountsSearch() => PartialView();

        public PartialViewResult GlMainAccountsData() => PartialView();

        public async Task<PartialViewResult> GlMainAccountsForm(long? id, string trigger)
        {
            if (id == null && trigger == FormTriggers.Insert.ToString())
            {
                ViewBag.trigger = trigger;

                return PartialView();
            }
            else if (id != null && trigger == FormTriggers.Update.ToString() ||
                trigger == FormTriggers.Show.ToString())
            {

                ViewBag.trigger = trigger;

                var currentRow = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetDetailAsync?Id={id}", RestSharp.Method.GET);

                var dataConverted = Helper<GlMainAccountsVM>.Convert(JsonConvert.SerializeObject(currentRow.result));

                var response = await _restClientContainer.SendRequest<RestResult>($"GlAccDetails/DrawGlAccController", RestSharp.Method.POST);

                ViewData["ListGlAccHeadersVM"] = response.result == null ? null : Helper<List<GlAccHeadersVM>>.Convert(JsonConvert.SerializeObject(response.result));

                return PartialView(dataConverted);
            }

            return PartialView();
        }

        public async Task<ActionResult> LoadDataGrid(GlMainAccountsParms searchParms)
        {
            var dtParms = DataTableParmsHelper.GetParms(Request.Form);

            var parameters = new GetAllPagedAndSortedWithParams<GlMainAccountsParms>()
            {
                Params = searchParms,
                OrderByValue = dtParms.sort,
                MaxResultCount = dtParms.pageSize,
                SkipCount = dtParms.skip
            };

            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetAll", RestSharp.Method.GET, parameters);

            var dataConverted = Helper<ListResultBaseWithTotalRecords<GlMainAccountsVM>>.Convert(JsonConvert.SerializeObject(response.result));

            int recordsTotal = dataConverted?.totalCount ?? 0;
            var data = dataConverted?.Items ?? new List<GlMainAccountsVM>();

            return Json(new { dtParms.draw, recordsFiltered = recordsTotal, recordsTotal, data }, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> PostGlMainAccounts(GlMainAccountsVM vm)
        {
            if (vm.Id == 0)
            {
                var response = new RestResult
                {
                    success = false,
                    customRestResult = new CustomRestResult()
                    {
                        trigger = FormTriggers.Insert.ToString(),
                        message = $"{Settings.Error}"
                    }
                };

                return Json(response, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/Update", RestSharp.Method.PUT, vm);

                response.customRestResult = new CustomRestResult()
                {
                    trigger = FormTriggers.Update.ToString(),
                    message = response.success ? Settings.UpdatedSuccessfully : $"{Settings.Error} : {response.error.message}"
                };

                return Json(response, JsonRequestBehavior.AllowGet);
            }
        }
    }
}