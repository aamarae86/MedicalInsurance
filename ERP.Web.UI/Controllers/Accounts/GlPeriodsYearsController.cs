using ERP.Front.Helpers.Core;
using ERP.Front.Helpers.DataTableHelpers;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Models.ViewModels.Accounts;
using ERP.WebUI.Controllers.Base;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using ERP.Front.Helpers.Parameters;
using ERP.Web.UI.Models.ResultModels;
using System;
using ERP.Authorization;
using ERP._System._GlPeriods.Dto;
using ERP.ResourcePack.Accounts;

namespace ERP.Web.UI.Controllers.Accounts
{
    public class GlPeriodsYearsController : BaseController
    {
        public GlPeriodsYearsController() : base("GlPeriodsYears", PermissionNames.Pages_GlPeriodsYears_Insert) { }

        #region Views
        public async Task<ActionResult> FormView(string id, string t)
        {
            var (allPermissions, insertPermission) = await GetMainPermissions();

            TempData["Permissions"] = allPermissions;

            ViewBag.trigger = CipherStringController.Decrypt(t);

            ViewData["Id"] = string.IsNullOrEmpty(id) ? null : CipherStringController.Decrypt(id);

            var response = await _restClientContainer.SendRequest<RestResult>(
                $"GlAccDetails/DrawGlAccController", RestSharp.Method.POST);

            ViewData["ListGlAccHeadersVM"] = response.result == null ?
                null :
                Helper<List<GlAccHeadersVM>>.Convert(JsonConvert.SerializeObject(response.result));

            if (!string.IsNullOrEmpty(id))
            {
                long decId = Convert.ToInt64(CipherStringController.Decrypt(id));

                if (!allPermissions.Contains(PermissionNames.Pages_GlPeriodsYears_Update))
                    return RedirectToAction("Index", "Home", new { area = string.Empty });

                var response2 = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetDetailAsync?Id={decId}", RestSharp.Method.GET);

                ViewData["DetailAsync"] = Helper<GlPeriodsYearsVM>.Convert(JsonConvert.SerializeObject(response2.result));
            }
            else
            {
                if (!insertPermission.Contains(PermissionNames.Pages_GlPeriodsYears_Insert))
                    return RedirectToAction("Index", "Home", new { area = string.Empty });
            }

            return View();
        }

        public PartialViewResult GlPeriodsYearsSearch() => PartialView();
        public PartialViewResult GlPeriodsYearsData() => PartialView();

        public PartialViewResult GlPeriodsYearsForm(long? id, string trigger, GlPeriodsYearsVM glPeriodsYearsVM, List<GlAccHeadersVM> glAccHeadersVMs)
        {
            ViewData["ListGlAccHeadersVM"] = glAccHeadersVMs;

            if (id == null && trigger == ERP.Front.Helpers.Enums.Common.FormTriggers.Insert.ToString())
            {
                ViewBag.trigger = trigger;

                return PartialView();
            }
            else if (id != null && trigger == ERP.Front.Helpers.Enums.Common.FormTriggers.Update.ToString() ||
                trigger == ERP.Front.Helpers.Enums.Common.FormTriggers.Show.ToString())
            {

                ViewBag.trigger = trigger;

                return PartialView(glPeriodsYearsVM);
            }

            return PartialView();
        }

        public PartialViewResult GlPeriodsYearsDataDetail() => PartialView();

        public PartialViewResult GlPeriodsYearsFormDetail(long? id, string trigger)
        {
            ViewBag.trigger = trigger;
            return PartialView();
        }

        #endregion

        #region Actions
        public async Task<ActionResult> LoadDataGrid(GlPeriodsYearsSearchDto searchParms)
        {
            var dtParms = DataTableParmsHelper.GetParms(Request.Form);

            var parameters = new GetAllPagedAndSortedWithParams<GlPeriodsYearsSearchDto>()
            {
                Params = searchParms,
                Sorting = dtParms.sort.PairAsSqlExpression,
                OrderByValue = dtParms.sort,
                MaxResultCount = dtParms.pageSize,
                SkipCount = dtParms.skip
            };

            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetAll", RestSharp.Method.GET, parameters);

            var dataConverted = Helper<ListResultBaseWithTotalRecords<GlPeriodsYearsVM>>.Convert(JsonConvert.SerializeObject(response.result));

            int recordsTotal = dataConverted?.totalCount ?? 0;
            var data = dataConverted?.Items ?? new List<GlPeriodsYearsVM>();

            return Json(new { dtParms.draw, recordsFiltered = recordsTotal, recordsTotal, data }, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> PostGlPeriodsYears(GlPeriodsYearsVM vm)
        {

            if (vm.PeriodDetails?.Count < 1)
            {
                var result = new RestResult
                {
                    success = false,
                    customRestResult = new CustomRestResult
                    {
                        message = GlPeriodsYears.MustAddAtLeastOneGlLine
                    }
                };
                return Json(result, JsonRequestBehavior.AllowGet);
            }

            if (vm.Id == 0)
            {
                var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/Create", RestSharp.Method.POST, vm);

                response.customRestResult = new CustomRestResult()
                {
                    trigger = ERP.Front.Helpers.Enums.Common.FormTriggers.Insert.ToString(),
                    message = response.success ? Settings.AddedSuccessfully : $"{Settings.Error} : {response.error.message}"
                };

                return Json(response, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/Update", RestSharp.Method.PUT, vm);

                response.customRestResult = new CustomRestResult()
                {
                    trigger = ERP.Front.Helpers.Enums.Common.FormTriggers.Update.ToString(),
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
        public async Task<ActionResult> IsExistingPeriod(string PeriodYear, string Id)
        {
            try
            {
                var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetIsExistingPeriodAsync?input={PeriodYear}&Id={Id}", RestSharp.Method.GET);
                var dataConverted = (bool)response.result;
                return Json(!dataConverted);
            }
            catch (Exception e)
            {
                return Json(false);
            }
        }

        #endregion
    }
}