using CrystalDecisions.CrystalReports.Engine;
using ERP._System.__AccountModule._ApInvoiceHd.Dto;
using ERP._System.PostRecords.Dto;
using ERP.Authorization;
using ERP.Front.Helpers.Core;
using ERP.Front.Helpers.DataTableHelpers;
using ERP.Front.Helpers.Parameters;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Models.ReportModels;
using ERP.Web.UI.Models.ResultModels;
using ERP.Web.UI.Models.ViewModels.Accounts;
using ERP.Web.UI.Models.ViewModels.AccountsExtend;
using ERP.WebUI.Controllers.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using static ERP.Front.Helpers.Enums.Common;

namespace ERP.Web.UI.Controllers.Accounts
{
    public class ApInvoiceHdController : BaseController
    {
        public ApInvoiceHdController() : base("ApInvoiceHd", PermissionNames.Pages_ApInvoiceHd_Insert) { }

        #region Views

        public async Task<ActionResult> FormView(string id, string t)
        {
            var (allPermissions, insertPermission) = await GetMainPermissions();

            TempData["Permissions"] = allPermissions;

            if (!insertPermission.Contains(PermissionNames.Pages_ApInvoiceHd_Insert))
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

                var glJeHeaders = Helper<ApInvoiceHdVM>.Convert(JsonConvert.SerializeObject(response2.result));

                ViewData["DetailAsync"] = glJeHeaders;
            }

            return View();
        }

        public PartialViewResult ApInvoiceHdSearch() => PartialView();
        public PartialViewResult ApInvoiceHdData() => PartialView();
        public PartialViewResult ApInvoiceHdForm(long? id, string trigger, ApInvoiceHdVM glJeHeadersVM, List<GlAccHeadersVM> glAccHeadersVMs)
        {
            ViewData["ListGlAccHeadersVM"] = glAccHeadersVMs;

            if (id == null && trigger == FormTriggers.Insert.ToString())
            {
                ViewBag.trigger = trigger;

                return PartialView();
            }
            else if (id != null && trigger == FormTriggers.Update.ToString() || trigger == FormTriggers.Show.ToString())
            {
                ViewBag.trigger = trigger;

                ViewData["Version"] = glJeHeadersVM.LastModificationTime;

                return PartialView(glJeHeadersVM);
            }

            return PartialView();
        }
        public PartialViewResult ApInvoiceHdDataDetail() => PartialView();
        public PartialViewResult ApInvoiceHdFormDetail(long? id, string trigger, List<GlAccHeadersVM> glAccHeadersVMs)
        {
            ViewBag.trigger = trigger;
            ViewData["ListGlAccHeadersVM"] = glAccHeadersVMs;
            return PartialView();
        }

        #endregion

        #region Actions

        public async Task<ActionResult> LoadDataGrid(ApInvoiceHdSearchDto searchParms)
        {
            var dtParms = DataTableParmsHelper.GetParms(Request.Form);

            var parameters = new GetAllPagedAndSortedWithParams<ApInvoiceHdSearchDto>()
            {
                Params = searchParms,
                Sorting = dtParms.sort.PairAsSqlExpression,
                OrderByValue = dtParms.sort,
                MaxResultCount = dtParms.pageSize,
                SkipCount = dtParms.skip
            };

            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetAll", RestSharp.Method.GET, parameters);

            var dataConverted = Helper<ListResultBaseWithTotalRecords<ApInvoiceHdVM>>.Convert(JsonConvert.SerializeObject(response.result));

            int recordsTotal = dataConverted?.totalCount ?? 0;
            var data = dataConverted?.Items ?? new List<ApInvoiceHdVM>();

            return Json(new { dtParms.draw, recordsFiltered = recordsTotal, recordsTotal, data }, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> CreateApInvoiceHd(ApInvoiceHdVM vm)
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

        public async Task<JsonResult> PrintApInvoiceHdScreen(string id, string lang)
        {
            long longId = Convert.ToInt64(CipherStringController.Decrypt(id));

            var input = new IdLangInputDto { Id = longId, Lang = lang };

            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetApInvoiceHdScreenData", RestSharp.Method.GET, input.ToString());

            if (response.success)
            {
                var dataConverted = Helper<List<ApInvoiceHdScreenDataOutput>>.Convert(JsonConvert.SerializeObject(response.result));
                var path = lang == "en-US" ? Server.MapPath("~/ReportsEn/rptInvoiceHdScreen_En.rpt"): Server.MapPath("~/Reports/rptInvoiceHdScreen.rpt");
                ReportDocument cryRpt = new ReportDocument();
                cryRpt.Load(path);
                cryRpt.SetDataSource(dataConverted);
                cryRpt.SetParameterValue("title", ERP.ResourcePack.Accounts.ReportsAccounts.rptInvoiceHdScreenTitle);
                Session["DocumentRpt"] = cryRpt;

                return Json(dataConverted, JsonRequestBehavior.AllowGet);
            }



            return Json(false, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}