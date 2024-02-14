using ERP._System.__AidModule._ScMaintenanceTechnicalReport.Dto;
using ERP.Authorization;
using ERP.Front.Helpers.Core;
using ERP.Front.Helpers.DataTableHelpers;
using ERP.Front.Helpers.Parameters;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Models.ResultModels;
using ERP.Web.UI.Models.ViewModels.Accounts;
using ERP.Web.UI.Models.ViewModels.AidModule;
using ERP.WebUI.Controllers.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using static ERP.Front.Helpers.Enums.Common;

namespace ERP.Web.UI.Controllers.AidModule
{
    public class ScMaintenanceTechnicalReportController : BaseController
    {
        public ScMaintenanceTechnicalReportController() : base("ScMaintenanceTechnicalReport", PermissionNames.Pages_ScMaintenanceTechnicalReport_Insert) { }

        #region Views

        public async Task<ActionResult> FormView(string id, string t)
        {
            var (allPermissions, insertPermission) = await GetMainPermissions();

            TempData["Permissions"] = allPermissions;

            if (!insertPermission.Contains(PermissionNames.Pages_ScMaintenanceTechnicalReport_Insert))
                return RedirectToAction("Index", "Home", new { area = string.Empty });

            ViewBag.trigger = CipherStringController.Decrypt(t);

            ViewData["Id"] = string.IsNullOrEmpty(id) ? null : CipherStringController.Decrypt(id);

            if (!string.IsNullOrEmpty(id))
            {
                long decId = Convert.ToInt64(CipherStringController.Decrypt(id));

                var response2 = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/Get?Id={decId}", RestSharp.Method.GET);

                ViewData["DetailAsync"] = Helper<ScMaintenanceTechnicalReportVM>.Convert(JsonConvert.SerializeObject(response2.result));
            }

            return View();
        }

        public PartialViewResult ScMaintenanceTechnicalReportSearch() => PartialView();
        public PartialViewResult ScMaintenanceTechnicalReportData() => PartialView();
        public PartialViewResult ScMaintenanceTechnicalReportForm(long? id, string trigger, ScMaintenanceTechnicalReportVM ScMaintenanceTechnicalReportVM)
        {

            if (id == null && trigger == FormTriggers.Insert.ToString())
            {
                ViewBag.trigger = trigger;

                return PartialView();
            }
            else if (id != null && trigger == FormTriggers.Update.ToString() || trigger == FormTriggers.Show.ToString())
            {
                ViewBag.trigger = trigger;
                ViewData["Version"] = ScMaintenanceTechnicalReportVM.LastModificationTime;

                return PartialView(ScMaintenanceTechnicalReportVM);
            }

            return PartialView();
        }
        public PartialViewResult AccountsLinesDataDetail() => PartialView();
        public PartialViewResult ScMaintenanceTechnicalReportQuotationsData() => PartialView();
        public PartialViewResult AccountsLinesFormDetail(long? id, string trigger, List<GlAccHeadersVM> glAccHeadersVMs)
        {
            ViewData["ListGlAccHeadersVM"] = glAccHeadersVMs;
            ViewBag.trigger = trigger;
            return PartialView();
        }
        public PartialViewResult CustomersLinesDataDetail() => PartialView();
        public PartialViewResult CustomersLinesFormDetail(long? id, string trigger)
        {
            ViewBag.trigger = trigger;
            return PartialView();
        }
        public PartialViewResult VendorsLinesDataDetail() => PartialView();
        public PartialViewResult VendorsLinesFormDetail(long? id, string trigger)
        {
            ViewBag.trigger = trigger;
            return PartialView();
        }
        #endregion

        #region Actions

        public async Task<ActionResult> LoadDataGrid(ScMaintenanceTechnicalReportSearchDto searchParms)
        {
            var dtParms = DataTableParmsHelper.GetParms(Request.Form);

            var parameters = new GetAllPagedAndSortedWithParams<ScMaintenanceTechnicalReportSearchDto>()
            {
                Params = searchParms,
                Sorting = dtParms.sort.PairAsSqlExpression,
                OrderByValue = dtParms.sort,
                MaxResultCount = dtParms.pageSize,
                SkipCount = dtParms.skip
            };

            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetAll", RestSharp.Method.GET, parameters);

            var dataConverted = Helper<ListResultBaseWithTotalRecords<ScMaintenanceTechnicalReportVM>>.Convert(JsonConvert.SerializeObject(response.result));

            int recordsTotal = dataConverted?.totalCount ?? 0;
            var data = dataConverted?.Items ?? new List<ScMaintenanceTechnicalReportVM>();

            return Json(new { dtParms.draw, recordsFiltered = recordsTotal, recordsTotal, data }, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> CreateScMaintenanceTechnicalReport(ScMaintenanceTechnicalReportVM vm)
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

        #endregion
    }
}