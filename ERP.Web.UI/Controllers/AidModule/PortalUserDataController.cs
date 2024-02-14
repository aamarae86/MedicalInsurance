using CrystalDecisions.CrystalReports.Engine;
using ERP._System.__AidModule._PortalUserUnified.Dto;
using ERP._System.PostRecords.Dto;
using ERP.Authorization;
using ERP.Front.Helpers.Core;
using ERP.Front.Helpers.DataTableHelpers;
using ERP.Front.Helpers.Parameters;
using ERP.MultiTenancy.Dto;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Models.ReportModels;
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
    public class PortalUserDataController : BaseController
    {
        public PortalUserDataController() : base("PortalUserData", PermissionNames.Pages_PortalUserData_Insert) { }

        #region Views

        public async Task<ActionResult> FormView(string id, string t, string tt = "")
        {
            var (allPermissions, insertPermission) = await GetMainPermissions();

            TempData["Permissions"] = allPermissions;

            ViewBag.trigger = CipherStringController.Decrypt(t);

            ViewData["Id"] = string.IsNullOrEmpty(id) ? null : CipherStringController.Decrypt(id);

            if (!string.IsNullOrEmpty(id))
            {
                long decId = Convert.ToInt64(CipherStringController.Decrypt(id));

                if (!allPermissions.Contains(PermissionNames.Pages_PortalUserData_Update))
                    return RedirectToAction("Index", "Home", new { area = string.Empty });

                var response2 = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/Get?Id={decId}", RestSharp.Method.GET);

                ViewData["DetailAsync"] = Helper<PortalUsersVM>.Convert(JsonConvert.SerializeObject(response2.result));
            }
            else
            {
                if (!insertPermission.Contains(PermissionNames.Pages_PortalUserData_Insert))
                    return RedirectToAction("Index", "Home", new { area = string.Empty });

                if (!string.IsNullOrEmpty(tt))
                {
                    long decId = Convert.ToInt64(CipherStringController.Decrypt(tt));

                    var response2 = await _restClientContainer.SendRequest<RestResult>($"PortalUserUnified/GetDetailAsync?Id={decId}", RestSharp.Method.GET);

                    var data = Helper<PortalUsersVM>.Convert(JsonConvert.SerializeObject(response2.result));

                    data.Id = 0;
                    data.PortalUserId = decId;
                    data.PortalUser = new PortalUsersVM { Name = data.Name };
                    data.FromUnifiedUser = true;

                    ViewData["DetailAsync"] = data;
                }
            }

            return View();
        }

        public PartialViewResult PortalUsersData() => PartialView();

        public PartialViewResult PortalUsersDataForm(long? id, string trigger, PortalUsersVM portalUsersVM)
        {
            ViewBag.trigger = trigger;

            return PartialView(portalUsersVM);
        }

        public PartialViewResult RelativesForm(long? id, string trigger)
        {
            ViewBag.trigger = trigger;
            return PartialView();
        }

        public PartialViewResult RelativesData() => PartialView();

        public PartialViewResult IncomesForm(long? id, string trigger)
        {
            ViewBag.trigger = trigger;
            return PartialView();
        }

        public PartialViewResult IncomesData() => PartialView();

        public PartialViewResult DutiesForm(long? id, string trigger)
        {
            ViewBag.trigger = trigger;
            return PartialView();
        }

        public PartialViewResult DutiesData() => PartialView();

        public PartialViewResult AidDataDetail() => PartialView();

        public PartialViewResult RefusedRequestsDataDetail() => PartialView();

        #endregion

        #region Actions

        public async Task<ActionResult> LoadDataGrid(PortalUserUnifiedSearchDto searchParms)
        {
            var dtParms = DataTableParmsHelper.GetParms(Request.Form);

            var parameters = new GetAllPagedAndSortedWithParams<PortalUserUnifiedSearchDto>()
            {
                Params = searchParms,
                Sorting = dtParms.sort.PairAsSqlExpression,
                OrderByValue = dtParms.sort,
                MaxResultCount = dtParms.pageSize,
                SkipCount = dtParms.skip
            };

            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetAll", RestSharp.Method.GET, parameters);

            var dataConverted = Helper<ListResultBaseWithTotalRecords<PortalUsersVM>>.Convert(JsonConvert.SerializeObject(response.result));

            int recordsTotal = dataConverted?.totalCount ?? 0;
            var data = dataConverted?.Items ?? new List<PortalUsersVM>();

            return Json(new { dtParms.draw, recordsFiltered = recordsTotal, recordsTotal, data }, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> PostPortalUserData(PortalUsersVM vm)
        {
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

        public async Task<JsonResult> PrintFndUsersScreen(string id, string lang, string type = null)
        {
            long longId = 0;

            longId = type == "c" ? Convert.ToInt64(CipherStringController.Decrypt(id)) : Convert.ToInt64(id);

            var input = new IdLangInputDto { Id = longId, Lang = lang };

            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetFndUsersScreenData", RestSharp.Method.GET, input.ToString());

            if (response.success)
            {
                var dataConverted = Helper<List<rptFndUsersScreenData>>.Convert(JsonConvert.SerializeObject(response.result));

                var tenantDetail = Session["tenantDetail"] as ERP.WebUI.Models.TenantDetailDto;

                var path = lang == "en-US" ? Server.MapPath("~/Reports/rptFndUsersScreen.rpt") : Server.MapPath("~/Reports/rptFndUsersScreen.rpt");


                ReportDocument cryRpt = new ReportDocument();

                cryRpt.Load(path);
                cryRpt.SetDataSource(dataConverted);

                cryRpt.SetParameterValue("title", "تفاصيل طلب المساعدة");
                cryRpt.SetParameterValue("Mname", tenantDetail?.ManagerName.ToString() ?? string.Empty);
                cryRpt.SetParameterValue("Nname", tenantDetail?.RepManagerName.ToString() ?? string.Empty);

                Session["DocumentRpt"] = cryRpt;

                return Json(dataConverted, JsonRequestBehavior.AllowGet);
            }

            return Json(false, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}