using CrystalDecisions.CrystalReports.Engine;
using ERP._System.__AccountModule._ArJobCardHd.Dto;
using ERP._System.PostRecords.Dto;
using ERP.Authorization;
using ERP.Front.Helpers.Core;
using ERP.Front.Helpers.DataTableHelpers;
using ERP.Front.Helpers.Parameters;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Models.ReportModels;
using ERP.Web.UI.Models.ResultModels;
using ERP.Web.UI.Models.ViewModels.Accounts;
using ERP.WebUI.Controllers.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using ERP.WebUI.Models;
using ERP._System._ArInvoiceHd.Dto;

namespace ERP.Web.UI.Controllers.Accounts
{
    public class ArJobCardHdController : BaseController
    {
        public ArJobCardHdController() : base("ArJobCardHd", PermissionNames.Pages_ArJobCardHd_Insert) { }

        public async Task<ActionResult> FormView(string id, string t)
        {
            var (allPermissions, insertPermission) = await GetMainPermissions();

            TempData["Permissions"] = allPermissions;

            ViewBag.trigger = CipherStringController.Decrypt(t);

            ViewData["Id"] = string.IsNullOrEmpty(id) ? null : CipherStringController.Decrypt(id);

            if (!string.IsNullOrEmpty(id))
            {
                long decId = Convert.ToInt64(CipherStringController.Decrypt(id));

                if (!allPermissions.Contains(PermissionNames.Pages_ArJobCardHd_Update))
                    return RedirectToAction("Index", "Home", new { area = string.Empty });

                var response2 = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetDetailAsync?Id={decId}", RestSharp.Method.GET);

                ViewData["DetailAsync"] = Helper<ArJobCardHdVM>.Convert(JsonConvert.SerializeObject(response2.result));
            }
            else
            {
                if (!insertPermission.Contains(PermissionNames.Pages_ArJobCardHd_Insert))
                    return RedirectToAction("Index", "Home", new { area = string.Empty });
            }

            return View();
        }

        public PartialViewResult ArJobCardHdSearch() => PartialView();

        public PartialViewResult ArJobCardHdData() => PartialView();

        public PartialViewResult ArJobCardPaymentsDataDetail() => PartialView();
        
        public PartialViewResult ArJobCardHdForm(long? id, string trigger, ArJobCardHdVM ArJobCardHdVM)
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

                return PartialView(ArJobCardHdVM);
            }

            return PartialView();
        }

        #region Actions

        public async Task<ActionResult> LoadDataGrid(ArJobCardHdSearchDto searchParms)
        {
            var dtParms = DataTableParmsHelper.GetParms(Request.Form);

            var parameters = new GetAllPagedAndSortedWithParams<ArJobCardHdSearchDto>()
            {
                Params = searchParms,
                Sorting = dtParms.sort.PairAsSqlExpression,
                OrderByValue = dtParms.sort,
                MaxResultCount = dtParms.pageSize,
                SkipCount = dtParms.skip
            };
            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetAll", RestSharp.Method.GET, parameters);
            var response2 = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetAllArJobCards", RestSharp.Method.GET, parameters);

            var dataConverted = Helper<ListResultBaseWithTotalRecords<ArJobCardHdVM>>.Convert(JsonConvert.SerializeObject(response.result));

            int recordsTotal = dataConverted?.totalCount ?? 0;
            var data = dataConverted?.Items ?? new List<ArJobCardHdVM>();

            return Json(new { dtParms.draw, recordsFiltered = recordsTotal, recordsTotal, data }, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> SaveArJobCardHd(ArJobCardHdVM vm)
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

        public async Task<ActionResult> Delete(int id)
        {
            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/Delete?Id={id}", RestSharp.Method.DELETE);

            response.customRestResult = new CustomRestResult()
            {
                message = response.success ? Settings.DeletedSuccessfully : $"{Settings.Error} : {response.error.message}"
            };

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> CloseArJobCard(ArJobCardHdDto input)
        {
            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/CloseArJobCard", RestSharp.Method.POST,input);

            response.customRestResult = new CustomRestResult()
            {
                message = response.success ? Settings.ClosedSuccessfully : $"{Settings.Error} : {response.error.message}"
            };

            return Json(response, JsonRequestBehavior.AllowGet);           
        }        

        public async Task<JsonResult> PrintArInvoiceHdScreen(string id, string lang)
        {

            try
            {
                long longId = Convert.ToInt64(CipherStringController.Decrypt(id));
                var langu = Request.Cookies["Lang"].Value;

                var input = new IdLangInputDto { Id = longId, Lang = lang };


                var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetArJobCardScreenData?Id={longId}", RestSharp.Method.GET);

                if (response.success)
                {
                    //var dataConverted = Helper<List<ArJobCardScreenDataOutput>>.Convert(JsonConvert.SerializeObject(response.result));
                    var dataConverted = Helper<List<ArJobCardScreenDataOutput>>.Convert(JsonConvert.SerializeObject(response.result));
                  

                    var customerInvoice = await _restClientContainer.SendRequest<RestResult>($"ArInvoiceHd/GetDetailBySourceId?Id={longId}", RestSharp.Method.GET);

                    var customerData = Helper<ArInvoiceHdDto>.Convert(JsonConvert.SerializeObject(customerInvoice.result));

                    var path = langu == "en-US" ? Server.MapPath("~/ReportsEn/rptArJobCardScreen_En.rpt") : Server.MapPath("~/Reports/rptArJobCardScreen.rpt");
                    var tenantDetail = Session["tenantDetail"] as TenantDetailDto;

                    ReportDocument cryRpt = new ReportDocument();
                    cryRpt.Load(path);
                    cryRpt.SetDataSource(dataConverted);
                    cryRpt.SetParameterValue("title", ERP.ResourcePack.Accounts.ReportsAccounts.rptArInvoiceHdScreenTitle);
                    cryRpt.SetParameterValue("TRN", tenantDetail.TaxRegNo??"TRN");
                    cryRpt.SetParameterValue("InvoiceDate", customerData?.HdDate??" ");
                    cryRpt.SetParameterValue("InvoiceNo", customerData?.HdInvoiceNo??" ");

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