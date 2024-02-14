using ERP._System.__AidModule._ScPortalRequestMgrDecision.Dto;
using ERP.Authorization;
using ERP.Front.Helpers.Core;
using ERP.Front.Helpers.DataTableHelpers;
using ERP.Front.Helpers.Parameters;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Models.ResultModels;
using ERP.Web.UI.Models.ViewModels.AidModule;
using ERP.WebUI.Controllers.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ERP.Web.UI.Controllers.AidModule
{
    public class ScPortalRequestMgrDecisionController : BaseController
    {
        public ScPortalRequestMgrDecisionController() : base("ScPortalRequestMgrDecision", PermissionNames.Pages_ScPortalRequestMgrDecision_Insert) { }
        #region Views

        public async Task<ActionResult> FormView(string id, string t)
        {
            var (allPermissions, insertPermission) = await GetMainPermissions();

            TempData["Permissions"] = allPermissions;

            ViewBag.trigger = CipherStringController.Decrypt(t);

            ViewData["Id"] = string.IsNullOrEmpty(id) ? null : CipherStringController.Decrypt(id);

            if (!string.IsNullOrEmpty(id))
            {
                long decId = Convert.ToInt64(CipherStringController.Decrypt(id));

                if (!allPermissions.Contains(PermissionNames.Pages_ScPortalRequestMgrDecision_Update))
                    return RedirectToAction("Index", "Home", new { area = string.Empty });

                var response2 = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetDetailAsync?Id={decId}", RestSharp.Method.GET);

                var rr = Helper<ScPortalRequestMgrDecisionVM>.Convert(JsonConvert.SerializeObject(response2.result));

                rr.FinalAmount = (rr.ScPortalRequestStudy.ScPortalRequest.MonthlyIncomeAmount - rr.ScPortalRequestStudy.ScPortalRequest.MonthlyOutcomeAmount).ToString();

                ViewData["DetailAsync"] = rr;
            }
            else
            {
                if (!insertPermission.Contains(PermissionNames.Pages_ScPortalRequestMgrDecision_Insert))
                    return RedirectToAction("Index", "Home", new { area = string.Empty });
            }

            return View();
        }

        public PartialViewResult ScPortalRequestMgrDecisionSearch() => PartialView();

        public PartialViewResult ScPortalRequestMgrDecisionData() => PartialView();

        public PartialViewResult ScPortalRequestMgrDecisionForm(long? id, string trigger, ScPortalRequestMgrDecisionVM scPortalRequestMgrDecisionVM)
        {
            if (id == null && trigger == Front.Helpers.Enums.Common.FormTriggers.Insert.ToString())
            {
                ViewBag.trigger = trigger;

                return PartialView();
            }
            else if (id != null && trigger == Front.Helpers.Enums.Common.FormTriggers.Update.ToString() ||
                trigger == Front.Helpers.Enums.Common.FormTriggers.Show.ToString())
            {

                ViewBag.trigger = trigger;

                return PartialView(scPortalRequestMgrDecisionVM);
            }

            return PartialView();
        }

        public PartialViewResult MgrDecisionElectronicAidsData() => PartialView();
        public PartialViewResult MgrDecisionElectronicAidsForm(long? id, string trigger)
        {
            ViewBag.trigger = trigger;
            return PartialView();
        }

        #endregion

        #region Actions

        public async Task<ActionResult> LoadDataGrid(ScPortalRequestMgrDecisionSearchDto searchParms)
        {
            var dtParms = DataTableParmsHelper.GetParms(Request.Form);

            var parameters = new GetAllPagedAndSortedWithParams<ScPortalRequestMgrDecisionSearchDto>()
            {
                Params = searchParms,
                Sorting = dtParms.sort.PairAsSqlExpression,
                OrderByValue = dtParms.sort,
                MaxResultCount = dtParms.pageSize,
                SkipCount = dtParms.skip
            };

            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetAll", RestSharp.Method.GET, parameters);

            var dataConverted = Helper<ListResultBaseWithTotalRecords<ScPortalRequestMgrDecisionVM>>.Convert(JsonConvert.SerializeObject(response.result));

            int recordsTotal = dataConverted?.totalCount ?? 0;
            var data = dataConverted?.Items ?? new List<ScPortalRequestMgrDecisionVM>();

            return Json(new { dtParms.draw, recordsFiltered = recordsTotal, recordsTotal, data }, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> PostScPortalRequestMgrDecision(ScPortalRequestMgrDecisionVM vm)
        {
            vm.FinalAmount = "0";

            if (vm.Id == 0)
            {
                var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/Create", RestSharp.Method.POST, vm);

                response.customRestResult = new CustomRestResult()
                {
                    trigger = Front.Helpers.Enums.Common.FormTriggers.Insert.ToString(),
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
        #endregion
    }
}