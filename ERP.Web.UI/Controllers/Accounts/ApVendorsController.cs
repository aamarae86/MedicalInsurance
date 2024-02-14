using ERP._System.__AccountModule._ApVendors.Dto;
using ERP.Authorization;
using ERP.Front.Helpers.Core;
using ERP.Front.Helpers.DataTableHelpers;
using ERP.Front.Helpers.Parameters;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Models.ResultModels;
using ERP.Web.UI.Models.ViewModels.Accounts;
using ERP.WebUI.Controllers.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using static ERP.Front.Helpers.Enums.Common;

namespace ERP.Web.UI.Controllers.Accounts
{
    public class ApVendorsController : BaseController
    {
        public ApVendorsController() : base("ApVendors", PermissionNames.Pages_ApVendors_Insert) { }

        public PartialViewResult ApVendorsSearch() => PartialView();

        public PartialViewResult ApVendorsData() => PartialView();

        public async Task<PartialViewResult> ApVendorsForm(long? id, string trigger)
        {
            if (id == null && trigger == FormTriggers.Insert.ToString())
            {
                ViewBag.trigger = trigger;

                return PartialView();
            }
            else if (id != null && trigger == FormTriggers.Update.ToString() || trigger == FormTriggers.Show.ToString())
            {
                var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetDetailAsync?Id={id}", RestSharp.Method.GET);

                var dataConverted = Helper<ApVendorsVM>.Convert(JsonConvert.SerializeObject(response.result));

                ViewBag.trigger = trigger;

                return PartialView(dataConverted);
            }

            return PartialView();
        }

        public async Task<ActionResult> LoadDataGrid(ApVendorsSearchDto searchParms)
        {
            var dtParms = DataTableParmsHelper.GetParms(Request.Form);

            var parameters = new GetAllPagedAndSortedWithParams<ApVendorsSearchDto>()
            {
                Params = searchParms,
                OrderByValue = dtParms.sort,
                SkipCount = dtParms.skip,
                MaxResultCount = dtParms.pageSize
            };

            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetAll", RestSharp.Method.GET, parameters);

            var dataConverted = Helper<ListResultBaseWithTotalRecords<ApVendorsVM>>.Convert(JsonConvert.SerializeObject(response.result));

            int recordsTotal = dataConverted?.totalCount ?? 0;
            var data = dataConverted?.Items ?? new List<ApVendorsVM>();

            return Json(new { dtParms.draw, recordsFiltered = recordsTotal, recordsTotal, data }, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> PostApVendors(ApVendorsVM vm)
        {
            if (vm.Id == 0)
            {
                var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/Create", RestSharp.Method.POST, vm);

                response.customRestResult = new CustomRestResult()
                {
                    trigger = FormTriggers.Insert.ToString(),
                    message = response.success ? Settings.AddedSuccessfully : $"{Settings.Error} : {response.error.message}"
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

        public async Task<ActionResult> Delete(int id)
        {
            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/Delete?Id={id}", RestSharp.Method.DELETE);

            response.customRestResult = new CustomRestResult()
            {
                message = response.success ? Settings.DeletedSuccessfully : $"{Settings.Error} : {response.error.message}"
            };

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> CheckIsExistsVendorNameAr(string VendorNameAr, string Id)
        {
            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetExistVendorNameArAsync?input={VendorNameAr}&Id={Id}", RestSharp.Method.GET);

            var dataConverted = (bool)response.result;

            return Json(!dataConverted);
        }

        [HttpPost]
        public async Task<ActionResult> CheckIsExistsVendorNameEn(string VendorNameEn, string Id)
        {

            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetExistVendorNameEnAsync?input={VendorNameEn}&Id={Id}", RestSharp.Method.GET);
          
            var dataConverted = (bool)response.result;
          
            return Json(!dataConverted);
        }
    }
}