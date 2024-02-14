using CrystalDecisions.CrystalReports.Engine;
using ERP._System.__AidModule._ScMaintenanceContract.Dto;
using ERP._System.PostRecords.Dto;
using ERP.Authorization;
using ERP.Front.Helpers.Core;
using ERP.Front.Helpers.DataTableHelpers;
using ERP.Front.Helpers.Parameters;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Models.ReportModels;
using ERP.Web.UI.Models.ResultModels;
using ERP.Web.UI.Models.ViewModels.AidModule;
using ERP.WebUI.Controllers.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using static ERP.Front.Helpers.Enums.Common;

namespace ERP.Web.UI.Controllers.AidModule
{
    public class ScMaintenanceContractController : BaseController
    {
        public ScMaintenanceContractController() : base("ScMaintenanceContract", PermissionNames.Pages_ScMaintenanceContract_Insert) { }

        #region Views
        public async Task<ActionResult> FormView(string id, string t)
        {
            var (allPermissions, insertPermission) = await GetMainPermissions();

            TempData["Permissions"] = allPermissions;

            if (!insertPermission.Contains(PermissionNames.Pages_ScMaintenanceContract_Insert))
                return RedirectToAction("Index", "Home", new { area = string.Empty });

            ViewBag.trigger = CipherStringController.Decrypt(t);

            ViewData["Id"] = string.IsNullOrEmpty(id) ? null : CipherStringController.Decrypt(id);

            if (!string.IsNullOrEmpty(id))
            {
                long decId = Convert.ToInt64(CipherStringController.Decrypt(id));

                var response2 = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/Get?Id={decId}", RestSharp.Method.GET);

                ViewData["DetailAsync"] = Helper<ScMaintenanceContractVM>.Convert(JsonConvert.SerializeObject(response2.result));
            }

            return View();
        }

        public PartialViewResult ScMaintenanceContractSearch() => PartialView();
        public PartialViewResult ScMaintenanceContractData() => PartialView();
        public PartialViewResult ScMaintenanceContractForm(long? id, string trigger, ScMaintenanceContractVM ScMaintenanceContractVM)
        {
            if (id == null && trigger == FormTriggers.Insert.ToString())
            {
                ViewBag.trigger = trigger;

                return PartialView();
            }
            else if (id != null && trigger == FormTriggers.Update.ToString() || trigger == FormTriggers.Show.ToString())
            {
                ViewBag.trigger = trigger;
                ViewData["Version"] = ScMaintenanceContractVM.LastModificationTime;

                return PartialView(ScMaintenanceContractVM);
            }

            return PartialView();
        }
        public PartialViewResult ScMaintenanceContractPaymentsData() => PartialView();
        public PartialViewResult ScMaintenanceContractPaymentsForm(long? id, string trigger)
        {
            ViewBag.trigger = trigger;
            return PartialView();
        }

        #endregion

        #region Actions

        public async Task<ActionResult> LoadDataGrid(ScMaintenanceContractSearchDto searchParms)
        {
            var dtParms = DataTableParmsHelper.GetParms(Request.Form);

            var parameters = new GetAllPagedAndSortedWithParams<ScMaintenanceContractSearchDto>()
            {
                Params = searchParms,
                Sorting = dtParms.sort.PairAsSqlExpression,
                OrderByValue = dtParms.sort,
                MaxResultCount = dtParms.pageSize,
                SkipCount = dtParms.skip
            };

            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetAll", RestSharp.Method.GET, parameters);

            var dataConverted = Helper<ListResultBaseWithTotalRecords<ScMaintenanceContractVM>>.Convert(JsonConvert.SerializeObject(response.result));

            int recordsTotal = dataConverted?.totalCount ?? 0;
            var data = dataConverted?.Items ?? new List<ScMaintenanceContractVM>();

            return Json(new { dtParms.draw, recordsFiltered = recordsTotal, recordsTotal, data }, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> CreateScMaintenanceContract(ScMaintenanceContractVM vm)
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

        public async Task<JsonResult> PrintScMaintenanceContractScreen(string id, string lang)
        {
            long longId = Convert.ToInt64(CipherStringController.Decrypt(id));

            var input = new IdLangInputDto { Id = longId, Lang = lang };

            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetScMaintenanceContractScreenData", RestSharp.Method.GET, input.ToString());

            if (response.success)
            {
                var dataConverted = Helper<List<GetScMaintenanceContractScreenDataOutputDto>>.Convert(JsonConvert.SerializeObject(response.result));
                //var tenantDetail = Session["tenantDetail"] as TenantDetailDto;

                //var path = tenantDetail.TenantId.ToString() == "2" ? Server.MapPath("~/Reports/rptMiscPaymentScreenT2.rpt") : (tenantDetail.TenantId.ToString() == "1" ? Server.MapPath("~/Reports/rptMiscPaymentScreen.rpt") : Server.MapPath("~/Reports/rptMiscPaymentScreenT3.rpt"));

                ReportDocument cryRpt = new ReportDocument();
              //  cryRpt.Load(path);
                cryRpt.SetDataSource(dataConverted);

                var parm = dataConverted.Where(x =>true/* x.DType == "B"*/).ToList();

               // cryRpt.SetParameterValue("TenantId", tenantDetail.TenantId.ToString());

                if (parm.Count() > 0)
                {
                    cryRpt.SetParameterValue("DetailsMaturityDate", parm[0].DetailsMaturityDate);
                    cryRpt.SetParameterValue("MaintenanceContractNumber", parm[0].MaintenanceContractNumber);

                }
                else
                {
                    cryRpt.SetParameterValue("DetailsMaturityDate", DateTime.Now);
                    cryRpt.SetParameterValue("MaintenanceContractNumber", "");
                }

                cryRpt.SetParameterValue("title", "عقود الصيانة");

                Session["DocumentRpt"] = cryRpt;
                return Json(dataConverted, JsonRequestBehavior.AllowGet);
            }

            return Json(false, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}