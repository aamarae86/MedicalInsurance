using CrystalDecisions.CrystalReports.Engine;
using ERP._System.__AccountModule._ArJobCardPaymentHd.Dto;
using ERP._System._ArInvoiceHd.Dto;
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
using static ERP.Front.Helpers.Enums.Common;

namespace ERP.Web.UI.Controllers.Accounts
{
    public class ArJobCardPaymentHdController : BaseController
    {
        public ArJobCardPaymentHdController() : base("ArJobCardPaymentHd", PermissionNames.Pages_ArJobCardPaymentHd_Insert) { }

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

                if (!allPermissions.Contains(PermissionNames.Pages_ArJobCardPaymentHd_Update))
                    return RedirectToAction("Index", "Home", new { area = string.Empty });

                var response2 = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetDetailAsync?Id={decId}", RestSharp.Method.GET);

               var data = Helper<ArJobCardPaymentHdVM>.Convert(JsonConvert.SerializeObject(response2.result));

                if(data != null)
                    data.JobNumberLkpId = data.ArJobCardHd.Id;

                ViewData["DetailAsync"] = data;
            }
            else
            {
                if (!insertPermission.Contains(PermissionNames.Pages_ArJobCardPaymentHd_Insert))
                    return RedirectToAction("Index", "Home", new { area = string.Empty });
            }

            return View();
        }
        public PartialViewResult ArJobCardPaymentHdSearch() => PartialView();
        public PartialViewResult ArJobCardPaymentHdData() => PartialView();

        public PartialViewResult ArJobCardPaymentHdForm(long? id, string trigger, ArJobCardPaymentHdVM glJeHeadersVM)
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

                return PartialView(glJeHeadersVM);
            }

            return PartialView();
        }
        public PartialViewResult ArJobCardPaymentHdDataDetail() => PartialView();
        public PartialViewResult ArJobCardPaymentHdFormDetail(long? id, string trigger, List<GlAccHeadersVM> glAccHeadersVMs)
        {
            ViewBag.trigger = trigger;
            ViewData["ListGlAccHeadersVM"] = glAccHeadersVMs;
            return PartialView();
        }


        public async Task<ActionResult> LoadDataGrid(ArJobCardPaymentHdSearchDto searchParms)
        {
            try
            {
                var dtParms = DataTableParmsHelper.GetParms(Request.Form);

                var parameters = new GetAllPagedAndSortedWithParams<ArJobCardPaymentHdSearchDto>()
                {
                    Params = searchParms,
                    Sorting = dtParms.sort.PairAsSqlExpression,
                    OrderByValue = dtParms.sort,
                    MaxResultCount = dtParms.pageSize,
                    SkipCount = dtParms.skip
                };

                var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetAll", RestSharp.Method.GET, parameters);

                var dataConverted = Helper<ListResultBaseWithTotalRecords<ArJobCardPaymentHdVM>>.Convert(JsonConvert.SerializeObject(response.result));

                int recordsTotal = dataConverted?.totalCount ?? 0;
                var data = dataConverted?.Items ?? new List<ArJobCardPaymentHdVM>();

                return Json(new { dtParms.draw, recordsFiltered = recordsTotal, recordsTotal, data }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<ActionResult> CreateArJobCardPaymentHd(ArJobCardPaymentHdVM vm)
        {
            if (string.IsNullOrEmpty(vm.ListArJobCardPaymentTr))
            {
                var result = new RestResult
                {
                    success = false,
                    customRestResult = new CustomRestResult
                    {
                        message = "Must Add One Line Item"
                    }
                };
                return Json(result, JsonRequestBehavior.AllowGet);
            }

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
                
        public async Task<JsonResult> PrintArJobCardPaymentHdScreen(string id, string lang)
        {
            try
            {
                long longId = Convert.ToInt64(CipherStringController.Decrypt(id));
                var langu = Request.Cookies["Lang"].Value;

                var input = new IdLangInputDto { Id = longId, Lang = lang };

                var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetAllArJobCardPaymentTrData?Id={longId}", RestSharp.Method.GET);

                if (response.success)
                {
                    var headerDetails = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetDetailAsync?Id={longId}", RestSharp.Method.GET);

                    var arjobcardpaymentHd = Helper<ArJobCardPaymentHdOutput>.Convert(JsonConvert.SerializeObject(headerDetails.result));
                    

                    //var dataConverted = Helper<List<ArJobCardScreenDataOutput>>.Convert(JsonConvert.SerializeObject(response.result));
                    var dataConverted = Helper<List<ArJobCardPaymentHdDataOutput>>.Convert(JsonConvert.SerializeObject(response.result));

                    if (dataConverted.Count == 0)
                    {
                        dataConverted = new List<ArJobCardPaymentHdDataOutput> { new ArJobCardPaymentHdDataOutput() };
                    }
                    

                    var path = langu == "en-US" ? Server.MapPath("~/ReportsEn/rptArJobCardPaymentScreen_En.rpt") : Server.MapPath("~/Reports/rptArJobCardPaymentScreen.rpt");
                    var tenantDetail = Session["tenantDetail"] as TenantDetailDto;

                    ReportDocument cryRpt = new ReportDocument();
                    cryRpt.Load(path);
                    cryRpt.SetDataSource(dataConverted);
                    cryRpt.SetParameterValue("title", ERP.ResourcePack.Accounts.ReportsAccounts.rptArInvoiceHdScreenTitle);
                    cryRpt.SetParameterValue("TransactionDate", arjobcardpaymentHd?.TransactionDate);
                    cryRpt.SetParameterValue("TransactionNumber", arjobcardpaymentHd?.TransactionNumber ?? " ");
                    cryRpt.SetParameterValue("Status", langu == "en-US" ? arjobcardpaymentHd?.FndJobCardPaymenStatusLkp.NameEn: arjobcardpaymentHd?.FndJobCardPaymenStatusLkp.NameAr);
                    //cryRpt.SetParameterValue("InvoiceNo", customerData?.HdInvoiceNo ?? " ");

                    Session["DocumentRpt"] = cryRpt;

                    return Json(dataConverted, JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception ex)
            {

                throw;
            }


            return Json(false, JsonRequestBehavior.AllowGet);
        }


        #endregion
    }
}