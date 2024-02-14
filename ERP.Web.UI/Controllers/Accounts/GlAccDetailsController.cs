using ERP.Authorization;
using ERP.Front.Helpers.Core;
using ERP.Front.Helpers.DataTableHelpers;
using ERP.Front.Helpers.Parameters;
using ERP.Helpers.Parameters.GlAccDetails;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Models.ResultModels;
using ERP.Web.UI.Models.ViewModels.Accounts;
using ERP.WebUI.Controllers.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ERP.Web.UI.Controllers.Accounts
{
    public class GlAccDetailsController : BaseController
    {
        public GlAccDetailsController() : base("GlAccDetails", PermissionNames.Pages_GlAccDetails_Insert) { }

        public PartialViewResult DrawGlAccController(List<GlAccHeadersVM> glAccHeadersVMs, string repeatTrigger = "")
        {
            ViewBag.repeatTrigger = repeatTrigger;

            return PartialView(glAccHeadersVMs);
        }

        public PartialViewResult GlAccDetailsSearch() => PartialView();

        public PartialViewResult GlAccDetailsData() => PartialView();

        public async Task<PartialViewResult> GlAccDetailsForm(int? id, string trigger)
        {
            if (id == null && trigger == ERP.Front.Helpers.Enums.Common.FormTriggers.Insert.ToString())
            {
                ViewBag.trigger = trigger;

                return PartialView();
            }
            else if (id != null && trigger == ERP.Front.Helpers.Enums.Common.FormTriggers.Update.ToString() ||
                trigger == ERP.Front.Helpers.Enums.Common.FormTriggers.Show.ToString())
            {
                var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetDetailAsync?Id={id}", RestSharp.Method.GET);

                var dataConverted = Helper<GlAccDetailsVM>.Convert(JsonConvert.SerializeObject(response.result));

                ViewBag.trigger = trigger;

                return PartialView(dataConverted);
            }

            return PartialView();
        }

        public async Task<ActionResult> LoadDataGrid(GlAccDetailsParms searchParms)
        {
            var dtParms = DataTableParmsHelper.GetParms(Request.Form);

            var parameters = new GetAllPagedAndSortedWithParams<GlAccDetailsParms>()
            {
                Params = searchParms,
                OrderByValue = dtParms.sort,
                MaxResultCount = dtParms.pageSize,
                SkipCount = dtParms.skip
            };

            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetAll", RestSharp.Method.GET, parameters);

            var dataConverted = Helper<ListResultBaseWithTotalRecords<GlAccDetailsVM>>.Convert(JsonConvert.SerializeObject(response.result));

            int recordsTotal = dataConverted?.totalCount ?? 0;
            var data = dataConverted?.Items ?? new List<GlAccDetailsVM>();

            return Json(new { dtParms.draw, recordsFiltered = recordsTotal, recordsTotal, data }, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> PostGlAccDetails(GlAccDetailsVM vm)
        {
            if (vm.Id == 0)
            {
                var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/Create", RestSharp.Method.POST, vm);

                var dataConverted = Helper<GlAccDetailsVM>.Convert(JsonConvert.SerializeObject(response.result));

                response.customRestResult = new CustomRestResult()
                {
                    trigger = ERP.Front.Helpers.Enums.Common.FormTriggers.Insert.ToString(),
                    message = response.success ?
                    (dataConverted.NameExistBefore ? Settings.NameExistBefore : (dataConverted.CodeExistBefore ? Settings.CodeExistBefore : Settings.AddedSuccessfully)) : $"{Settings.Error} : {response.error.message}"
                };

                return Json(response, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/Update", RestSharp.Method.PUT, vm);

                var dataConverted = Helper<GlAccDetailsVM>.Convert(JsonConvert.SerializeObject(response.result));

                response.customRestResult = new CustomRestResult()
                {
                    trigger = ERP.Front.Helpers.Enums.Common.FormTriggers.Update.ToString(),
                    message = response.success ?
                    (dataConverted.NameExistBefore ? Settings.NameExistBefore : (dataConverted.CodeExistBefore ? Settings.CodeExistBefore : Settings.UpdatedSuccessfully)) : $"{Settings.Error} : {response.error.message}"
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
        public async Task<ActionResult> CheckNameExist(long? Id, string NameAr, string NameEn)
        {
            try
            {
                var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/NameExist?id={Id}&nameAr={NameAr}&nameEn={NameEn}", RestSharp.Method.POST);

                var dataConverted = (bool)response.result;

                return Json(!dataConverted);
            }
            catch (Exception x)
            {
                return Json(false);
            }
        }

        [HttpPost]
        public async Task<ActionResult> CheckCodeExist(long? Id, string Code)
        {
            try
            {
                var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/CodeExist?id={Id}&code={Code}", RestSharp.Method.POST);

                var dataConverted = (bool)response.result;

                return Json(!dataConverted);
            }
            catch (Exception x)
            {
                return Json(false);
            }
        }
    }
}