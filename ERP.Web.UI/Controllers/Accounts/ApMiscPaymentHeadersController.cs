using CrystalDecisions.CrystalReports.Engine;
using ERP._System._ArMiscPayment._ApMiscPaymentHeaders.Dto;
using ERP._System.PostRecords.Dto;
using ERP.Authorization;
using ERP.Front.Helpers.Core;
using ERP.Front.Helpers.DataTableHelpers;
using ERP.Front.Helpers.Parameters;
using ERP.ResourcePack.Accounts;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Models.ReportModels;
using ERP.Web.UI.Models.ResultModels;
using ERP.Web.UI.Models.ViewModels.Accounts;
using ERP.WebUI.Controllers.Base;
using ERP.WebUI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using CipherStringController = ERP.Front.Helpers.Core.CipherStringController;

namespace ERP.Web.UI.Controllers.Accounts
{
    public class ApMiscPaymentHeadersController : BaseController
    {
        public ApMiscPaymentHeadersController() :  base("ApMiscPaymentHeaders", PermissionNames.Pages_ApMiscPaymentHeaders_Insert)
        { }

        #region Views

        public async Task<ActionResult> FormView(string id, string t)
        {
            var (allPermissions, insertPermission) = await GetMainPermissions();

            TempData["Permissions"] = allPermissions;
 
            if (!insertPermission.Contains(PermissionNames.Pages_ApMiscPaymentHeaders_Insert))
                return RedirectToAction("Index", "Home", new { area = string.Empty });

            ViewBag.trigger = CipherStringController.Decrypt(t);

            ViewData["Id"] = string.IsNullOrEmpty(id) ? null : CipherStringController.Decrypt(id);

            var response = await _restClientContainer.SendRequest<RestResult>($"GlAccDetails/DrawGlAccController", RestSharp.Method.POST);

            ViewBag.IsNotPosted = true;

            ViewData["ListGlAccHeadersVM"] = response.result == null ? null : Helper<List<GlAccHeadersVM>>.Convert(JsonConvert.SerializeObject(response.result));

            if (!string.IsNullOrEmpty(id))
            {
                long decId = Convert.ToInt64(CipherStringController.Decrypt(id));

                var response2 = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetDetailAsync?Id={decId}", RestSharp.Method.GET);

                ApMiscPaymentHeadersVM apMiscPaymentHeadersVM = Helper<ApMiscPaymentHeadersVM>.Convert(JsonConvert.SerializeObject(response2.result));
                ViewData["DetailAsync"] = apMiscPaymentHeadersVM;
            }

            return View();
        }

        public PartialViewResult ApMiscPaymentHeadersSearch() => PartialView();
        public PartialViewResult ApMiscPaymentHeadersData() => PartialView();
        public PartialViewResult ApMiscPaymentHeadersForm(long? id, string trigger, ApMiscPaymentHeadersVM ApMiscPaymentHeadersVM)
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

                return PartialView(ApMiscPaymentHeadersVM);
            }

            return PartialView();
        }
        public PartialViewResult ApMiscPaymentHeadersFormDetail(long? id, string trigger, List<GlAccHeadersVM> glAccHeadersVMs)
        {
            ViewBag.trigger = trigger;
            ViewData["ListGlAccHeadersVM"] = glAccHeadersVMs;

            return PartialView();
        }
        public PartialViewResult ApMiscPaymentHeadersDataDetail() => PartialView();
        public PartialViewResult ApMiscPaymentHeadersFormDetail2(long? id, string trigger)
        {
            ViewBag.trigger = trigger;
            return PartialView();
        }

        public PartialViewResult ApMiscPaymentHeadersDataDetail2() => PartialView();

        #endregion

        #region Actions
        public async Task<ActionResult> LoadDataGrid(ArMiscPaymentHeadersSearchDto searchParms)
        {
            var dtParms = DataTableParmsHelper.GetParms(Request.Form);

            var parameters = new GetAllPagedAndSortedWithParams<ArMiscPaymentHeadersSearchDto>()
            {
                Params = searchParms,
                OrderByValue = dtParms.sort,
                MaxResultCount = dtParms.pageSize,
                SkipCount = dtParms.skip
            };

            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetAll", RestSharp.Method.GET, parameters);

            var dataConverted = Helper<ListResultBaseWithTotalRecords<ApMiscPaymentHeadersVM>>.Convert(JsonConvert.SerializeObject(response.result));

            int recordsTotal = dataConverted?.totalCount ?? 0;
            var data = dataConverted?.Items ?? new List<ApMiscPaymentHeadersVM>();

            return Json(new { dtParms.draw, recordsFiltered = recordsTotal, recordsTotal, data }, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> CreateApMiscPaymentHeaders(ApMiscPaymentHeadersVM vm)
        {

            if (string.IsNullOrEmpty(vm.ListApMiscPaymentLines))
            {
                var result = new RestResult
                {
                    success = false,
                    customRestResult = new CustomRestResult
                    {
                        message = ApMiscPaymentHeaders.FillDetailTable
                    }
                };

                return Json(result, JsonRequestBehavior.AllowGet);
            }

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
                    trigger = Front.Helpers.Enums.Common.FormTriggers.Update.ToString(),
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

        public async Task<JsonResult> PrintMiscPaymentScreen(string id,string lang)
        {
            long longId = Convert.ToInt64(CipherStringController.Decrypt(id));

            var input = new IdLangInputDto { Id = longId, Lang = lang };

            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetMiscPaymentScreenData", RestSharp.Method.GET, input.ToString());

            if (response.success)
            {
                var dataConverted = Helper<List<rptMiscPaymentScreenData>>.Convert(JsonConvert.SerializeObject(response.result));
                var tenantDetail = Session["tenantDetail"] as TenantDetailDto;
                var path = lang == "en-US" ? Server.MapPath("~/ReportsEn/rptMiscPaymentScreen_En.rpt") : Server.MapPath("~/Reports/rptMiscPaymentScreen.rpt");

                //var path = tenantDetail.TenantId.ToString() == "2" ? Server.MapPath("~/Reports/rptMiscPaymentScreenT2.rpt") : (tenantDetail.TenantId.ToString() == "1" ? Server.MapPath("~/Reports/rptMiscPaymentScreen.rpt"): Server.MapPath("~/Reports/rptMiscPaymentScreenT3.rpt"));

                ReportDocument cryRpt = new ReportDocument();
                cryRpt.Load(path);
                cryRpt.SetDataSource(dataConverted);

                var parm = dataConverted.Where(x => x.DType == "B").ToList();

              
                cryRpt.SetParameterValue("TenantId", tenantDetail.TenantId.ToString());

                if (parm.Count() > 0)
                {
                    cryRpt.SetParameterValue("MaturityDate", parm[0].MaturityDate);
                    cryRpt.SetParameterValue("CheckNumber", parm[0].CheckNumber);
                    cryRpt.SetParameterValue("DetailsBeneficiaryName", parm[0].DetailsBeneficiaryName);
                    cryRpt.SetParameterValue("CheckAmount", parm[0].CheckAmount);
                    cryRpt.SetParameterValue("AmountTafqeet", parm[0].AmountTafqeet);
                    cryRpt.SetParameterValue("Check", "1");

                }
                else
                {
                    cryRpt.SetParameterValue("MaturityDate", DateTime.Now);
                    cryRpt.SetParameterValue("CheckNumber", "");
                    cryRpt.SetParameterValue("DetailsBeneficiaryName", "");
                    cryRpt.SetParameterValue("CheckAmount", 0);
                    cryRpt.SetParameterValue("AmountTafqeet", "");
                    cryRpt.SetParameterValue("Check", "0");
                }

                cryRpt.SetParameterValue("title", "سند صرف عام");

                Session["DocumentRpt"] = cryRpt;
                return Json(dataConverted, JsonRequestBehavior.AllowGet);
            }



            return Json(false, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}