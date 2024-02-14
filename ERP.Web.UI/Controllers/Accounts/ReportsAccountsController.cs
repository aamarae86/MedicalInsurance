using CrystalDecisions.CrystalReports.Engine;
using ERP._System.__AccountModule._ApPdcInterface.ProcDto;
using ERP._System.__AccountModule._ArSecurityDepositInterface.Input;
using ERP._System.__ReportsAccounts.Inputs;
using ERP._System._SpDtos._TaxReportData;
using ERP._System._SpDtos._TaxReportData2;
using ERP.Front.Helpers.Core;
using ERP.Web.UI.Models.ReportModels;
using ERP.Web.UI.Models.ViewModels.Accounts;
using ERP.WebUI.Controllers.Base;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using GetApPdcInterfaceDataOutput = ERP.Web.UI.Models.ReportModels.GetApPdcInterfaceDataOutput;
using GetArPdcInterfaceDataOutput = ERP.Web.UI.Models.ReportModels.GetArPdcInterfaceDataOutput;

namespace ERP.Web.UI.Controllers.Accounts
{
    public class ReportsAccountsController : BaseController
    {
        public ReportsAccountsController() : base("ReportsAccounts", string.Empty) { }

        public ActionResult FaAssetList() => View();

        public ActionResult SecurityDetailsList() => View();

        public ActionResult ApPdcInterfaceReport() => View();

        public ActionResult ArPdcInterfaceReport() => View();

        public ActionResult GlAccounts() => View();

        public ActionResult TaxReports() => View();

        public ActionResult Tax2Reports() => View();

        public async override Task<ActionResult> Index()
        {
            var response = await _restClientContainer.SendRequest<RestResult>($"GlAccDetails/DrawGlAccController", RestSharp.Method.POST);

            var data = response.result == null ? null : Helper<List<GlAccHeadersVM>>.Convert(JsonConvert.SerializeObject(response.result));

            return View(data);
        }

        public async Task<ActionResult> GlAccSelection()
        {
            var response = await _restClientContainer.SendRequest<RestResult>($"GlAccDetails/DrawGlAccController", RestSharp.Method.POST);

            var data = response.result == null ? null : Helper<List<GlAccHeadersVM>>.Convert(JsonConvert.SerializeObject(response.result));

            return View(data);
        }

        public async Task<ActionResult> BudgetPerformance()
        {
            var response = await _restClientContainer.SendRequest<RestResult>($"GlAccDetails/DrawGlAccController", RestSharp.Method.POST);

            var data = response.result == null ? null : Helper<List<GlAccHeadersVM>>.Convert(JsonConvert.SerializeObject(response.result));

            return View(data);
        }

        [HttpPost]
        public async Task<JsonResult> PrintSecurityDetailsList(GetArSecurityDepositInterfacerptInputHelper input)
        {
            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetArSecurityDepositInterfacerpt", RestSharp.Method.GET, input.ToString());

            if (response.success)
            {
                var dataConverted = Helper<List<Models.ReportModels.rptGetArSecurityDepositInterfacerptOutput>>.Convert(JsonConvert.SerializeObject(response.result));

                var path = input.Lang == "en-US" ? Server.MapPath("~/ReportsEn/rptSecurityDetailsList_En.rpt") : Server.MapPath("~/Reports/rptSecurityDetailsList.rpt");

                ReportDocument cryRpt = new ReportDocument();
                cryRpt.Load(path);
                cryRpt.SetDataSource(dataConverted);

                cryRpt.SetParameterValue("title", ERP.ResourcePack.Accounts.ReportsAccounts.rptSecurityDetailsListTitle);
                cryRpt.SetParameterValue("StatusLkpIdtxt", string.IsNullOrEmpty(input.StatusLkpIdtxt) ? "" : input.StatusLkpIdtxt);
                cryRpt.SetParameterValue("ArCustomerIdtxt", string.IsNullOrEmpty(input.ArCustomerIdtxt) ? "" : input.ArCustomerIdtxt);

                Session["DocumentRpt"] = cryRpt;
                return Json(dataConverted, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<JsonResult> PrintAccountStatment(AccountsStatmentHelperInput input)
        {
            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetAccountStatment", RestSharp.Method.GET, input.ToString());

            if (response.success)
            {
                var dataConverted = Helper<List<Models.ReportModels.AccountsStatmentOutput>>.Convert(JsonConvert.SerializeObject(response.result));

                var path = input.Lang == "en-US" ? Server.MapPath("~/ReportsEn/RPT_Get_GL_JE_En.rpt") : Server.MapPath("~/Reports/RPT_Get_GL_JE.rpt");

                ReportDocument cryRpt = new ReportDocument();
                cryRpt.Load(path);
                cryRpt.SetDataSource(dataConverted);

                cryRpt.SetParameterValue("title", ERP.ResourcePack.Accounts.ReportsAccounts.RPT_Get_GL_JE_EnTitle);
                cryRpt.SetParameterValue("From_Date", string.IsNullOrEmpty(input.FromDateStr) ? "" : input.FromDateStr);
                cryRpt.SetParameterValue("To_Date", string.IsNullOrEmpty(input.ToDateStr) ? "" : input.ToDateStr);

                Session["DocumentRpt"] = cryRpt;
                return Json(dataConverted, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<JsonResult> PrintFaAssetList(GetFaAssetListDataInputHelper input)
        {
            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetFaAssetListData", RestSharp.Method.GET, input.ToString());

            if (response.success)
            {
                var dataConverted = Helper<List<Models.ReportModels.rptGetFaAssetListDataOutput>>.Convert(JsonConvert.SerializeObject(response.result));

                var path = input.Lang == "en-US" ? Server.MapPath("~/ReportsEn/rptFaAssetList_En.rpt") : Server.MapPath("~/Reports/rptFaAssetList.rpt");

                ReportDocument cryRpt = new ReportDocument();
                cryRpt.Load(path);
                cryRpt.SetDataSource(dataConverted);

                cryRpt.SetParameterValue("title", ERP.ResourcePack.Accounts.ReportsAccounts.rptFaAssetListTitle);
                cryRpt.SetParameterValue("From_Date", string.IsNullOrEmpty(input.FromDate) ? "" : input.FromDate);
                cryRpt.SetParameterValue("To_Date", string.IsNullOrEmpty(input.ToDate) ? "" : input.ToDate);
                cryRpt.SetParameterValue("StatusLkpIdtxt", string.IsNullOrEmpty(input.StatusLkpIdtxt) ? "" : input.StatusLkpIdtxt);
                cryRpt.SetParameterValue("FaAssetCategoryIdtxt", string.IsNullOrEmpty(input.FaAssetCategoryIdtxt) ? "" : input.FaAssetCategoryIdtxt);
                cryRpt.SetParameterValue("Description", string.IsNullOrEmpty(input.Description) ? "" : input.Description);

                Session["DocumentRpt"] = cryRpt;
                return Json(dataConverted, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<JsonResult> PrintBudgetPerformance(rptGlAccMappingHdHelperInput input)
        {
            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetrptGlAccMappingHd", RestSharp.Method.GET, input.ToString());

            if (response.success)
            {
                var dataConverted = Helper<List<Models.ReportModels.rptrptGlAccMappingHdOutput>>.Convert(JsonConvert.SerializeObject(response.result));

                var path = input.Lang == "en-US" ? Server.MapPath("~/ReportsEn/rptGlAccMappingHd_En.rpt") : Server.MapPath("~/Reports/rptGlAccMappingHd.rpt");

                ReportDocument cryRpt = new ReportDocument();
                cryRpt.Load(path);
                cryRpt.SetDataSource(dataConverted);

                cryRpt.SetParameterValue("title", input.GlAccMappingHdIdtxt);
                cryRpt.SetParameterValue("PeriodIdTotxt", string.IsNullOrEmpty(input.PeriodIdTotxt) ? "" : input.PeriodIdTotxt);
                cryRpt.SetParameterValue("PeriodIdFromtxt", string.IsNullOrEmpty(input.PeriodIdFromtxt) ? "" : input.PeriodIdFromtxt);

                Session["DocumentRpt"] = cryRpt;
                return Json(dataConverted, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<JsonResult> PrintAccounts(GlAccountsrptVM input)
        {
            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetGlAccountsScreenDatarpt", RestSharp.Method.GET, input.ToString());

            if (response.success)
            {
                var dataConverted = Helper<List<rptGlAccountsScreenDatarpt>>.Convert(JsonConvert.SerializeObject(response.result));

                var path = input.Lang == "en-US" ? Server.MapPath("~/ReportsEn/rptAccountsTree_En.rpt") : Server.MapPath("~/Reports/rptAccountsTree.rpt");

                ReportDocument cryRpt = new ReportDocument();
                cryRpt.Load(path);
                cryRpt.SetDataSource(dataConverted);

                cryRpt.SetParameterValue("title",ERP.ResourcePack.Accounts.ReportsAccounts.rptAccountsTreeTitle );
                cryRpt.SetParameterValue("Level",input.Level);

                Session["DocumentRpt"] = cryRpt;
                return Json(dataConverted, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<JsonResult> PrintAccountBalance(int level, string keyType,string FromDateStr,string ToDateStr)
        {
            var action = keyType == "BalanceReview" ? "GetgltrialbalancesRPT" :
              (keyType == "Budget" ? "GetGeneralBALANCE_SHEETRPT" :
               (keyType == "ListIncomes" ? "GetGeneralProLosRPT" : string.Empty));
            
            if (action == string.Empty) return Json(false, JsonRequestBehavior.AllowGet);
            
            ReportDocument cryRpt = new ReportDocument();
            var lang = Request.Cookies["Lang"].Value;
            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/{action}?level={level}&lang={lang}", RestSharp.Method.GET);
            
            if (response.success)
            {
                if (action == "GetGeneralProLosRPT")
                {
                    var dataConverted = Helper<List<rptGlAccProLosOutput>>.Convert(JsonConvert.SerializeObject(response.result));
                    var path = lang == "en-US" ?  Server.MapPath("~/ReportsEn/RPT_GetGeneralBalanceSheet_En.rpt") :Server.MapPath("~/Reports/RPT_GetGeneralBalanceSheet.rpt");

                    cryRpt.Load(path);
                    cryRpt.SetDataSource(dataConverted);

                    cryRpt.SetParameterValue("title", ERP.ResourcePack.Accounts.ReportsAccounts.RPT_GetGeneralBalanceSheetTitle);
                    cryRpt.SetParameterValue("From", string.IsNullOrEmpty(FromDateStr) ? "" : FromDateStr);
                    cryRpt.SetParameterValue("To", string.IsNullOrEmpty(ToDateStr) ? "" : ToDateStr);

                    Session["DocumentRpt"] = cryRpt;
                    return Json(dataConverted, JsonRequestBehavior.AllowGet);

                }
                else if (action == "GetgltrialbalancesRPT")
                {
                    var dataConverted = Helper<List<rptGlAccBalanceOutput>>.Convert(JsonConvert.SerializeObject(response.result));
                    //var path = input.Lang == "en-US" ? Server.MapPath("~/Reports/RPT_Get_GL_JE.rpt") : Server.MapPath("~/Reports/RPT_Get_GL_JE.rpt");
                    var path = lang == "en-US" ? Server.MapPath("~/ReportsEn/RPT_Getgltrialbalances_En.rpt") :Server.MapPath("~/Reports/RPT_Getgltrialbalances.rpt");

                    cryRpt.Load(path);
                    cryRpt.SetDataSource(dataConverted);

                    cryRpt.SetParameterValue("title", ERP.ResourcePack.Accounts.ReportsAccounts.RPT_GetgltrialbalancesTitle);
                    cryRpt.SetParameterValue("From", string.IsNullOrEmpty(FromDateStr) ? "" : FromDateStr);
                    cryRpt.SetParameterValue("To", string.IsNullOrEmpty(ToDateStr) ? "" : ToDateStr);

                    Session["DocumentRpt"] = cryRpt;
                    return Json(dataConverted, JsonRequestBehavior.AllowGet);
                }
                else if (action == "GetGeneralBALANCE_SHEETRPT")
                {
                    var dataConverted = Helper<List<rptGlAccBalanceSheetOutput>>.Convert(JsonConvert.SerializeObject(response.result));
                    //var path = input.Lang == "en-US" ? Server.MapPath("~/Reports/RPT_Get_GL_JE.rpt") : Server.MapPath("~/Reports/RPT_Get_GL_JE.rpt");
                    var path = lang == "en-US" ? Server.MapPath("~/ReportsEn/RPT_GetGeneralBalanceSheet_En.rpt"): Server.MapPath("~/Reports/RPT_GetGeneralBalanceSheet.rpt");

                    cryRpt.Load(path);
                    cryRpt.SetDataSource(dataConverted);

                    cryRpt.SetParameterValue("title", ERP.ResourcePack.Accounts.ReportsAccounts.RPT_GetGeneralBalanceSheetTitlee);
                    cryRpt.SetParameterValue("From", string.IsNullOrEmpty(FromDateStr) ? "" : FromDateStr);
                    cryRpt.SetParameterValue("To", string.IsNullOrEmpty(ToDateStr) ? "" : ToDateStr);

                    Session["DocumentRpt"] = cryRpt;
                    return Json(dataConverted, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(false, JsonRequestBehavior.AllowGet);
                }

                //var path = input.Lang == "en-US" ? Server.MapPath("~/Reports/RPT_Get_GL_JE.rpt") : Server.MapPath("~/Reports/RPT_Get_GL_JE.rpt");

                //ReportDocument cryRpt = new ReportDocument();
                //cryRpt.Load(path);
                //cryRpt.SetDataSource(dataConverted);

                //cryRpt.SetParameterValue("title", "كشف حركه حساب");
                //cryRpt.SetParameterValue("From_Date", string.IsNullOrEmpty(input.FromDateStr) ? "" : input.FromDateStr);
                //cryRpt.SetParameterValue("To_Date", string.IsNullOrEmpty(input.ToDateStr) ? "" : input.ToDateStr);

                //Session["DocumentRpt"] = cryRpt;

            }

            return Json(false, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<JsonResult> PrintApPdcInterfaceReport(GetApPdcInterfaceDataInputHelper input)
        {
            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetApPdcInterfaceData", RestSharp.Method.GET, input.ToString());

            if (response.success)
            {
                var lang = Request.Cookies["Lang"].Value;
                var dataConverted = Helper<List<GetApPdcInterfaceDataOutput>>.Convert(JsonConvert.SerializeObject(response.result));

                var path = lang == "en-US" ? Server.MapPath("~/ReportsEn/rptApPdcInterfaceReport_En.rpt") : Server.MapPath("~/Reports/rptApPdcInterfaceReport.rpt");

                ReportDocument cryRpt = new ReportDocument();
                cryRpt.Load(path);
                cryRpt.SetDataSource(dataConverted);
                cryRpt.SetParameterValue("title", ERP.ResourcePack.Accounts.ReportsAccounts.ApPdcInterface);
                cryRpt.SetParameterValue("fromDate", input.FromDate ?? "---");
                cryRpt.SetParameterValue("toDate", input.ToDate ?? "---");
                cryRpt.SetParameterValue("statusName", input.StatusLkpIdtxt ?? "---");

                Session["DocumentRpt"] = cryRpt;
                return Json(dataConverted, JsonRequestBehavior.AllowGet);
            }

            return Json(false, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<JsonResult> PrintArPdcInterfaceReport(GetArPdcInterfaceDataInputHelper input)
        {
            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetArPdcInterfaceData", RestSharp.Method.GET, input.ToString());

            if (response.success)
            {
                var lang = Request.Cookies["Lang"].Value;
                var dataConverted = Helper<List<GetArPdcInterfaceDataOutput>>.Convert(JsonConvert.SerializeObject(response.result));

                var path = lang == "en-US" ? Server.MapPath("~/ReportsEn/rptArPdcInterfaceReport_En.rpt") : Server.MapPath("~/Reports/rptArPdcInterfaceReport.rpt");

                ReportDocument cryRpt = new ReportDocument();
                cryRpt.Load(path);
                cryRpt.SetDataSource(dataConverted);                
                cryRpt.SetParameterValue("title", ERP.ResourcePack.Accounts.ReportsAccounts.ArPdcInterfaceReportTitle);
                cryRpt.SetParameterValue("fromDate", input.FromDate ?? "---");
                cryRpt.SetParameterValue("toDate", input.ToDate ?? "---");
                cryRpt.SetParameterValue("statusName", input.StatusLkpIdtxt ?? "---");
                
                Session["DocumentRpt"] = cryRpt;
                return Json(dataConverted, JsonRequestBehavior.AllowGet);
            }

            return Json(false, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<JsonResult> PrintTaxReports(GetTaxReportDataInputHelper input)
        {
            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetTaxReportData", RestSharp.Method.GET, input.ToString());
            var lang = Request.Cookies["Lang"].Value;
            if (response.success)
            {
                var dataConverted = Helper<List<GetTaxReportDataOutputHelper>>.Convert(JsonConvert.SerializeObject(response.result));
                var path = lang == "en-US" ?Server.MapPath("~/ReportsEn/rptTaxReport_En.rpt") : Server.MapPath("~/Reports/rptTaxReport.rpt");
                ReportDocument cryRpt = new ReportDocument();
                cryRpt.Load(path);
                cryRpt.SetDataSource(dataConverted);
                cryRpt.SetParameterValue("title", ERP.ResourcePack.Accounts.ReportsAccounts.TaxInput);
                cryRpt.SetParameterValue("fromDate", string.IsNullOrEmpty(input.FromDate) ? "---" : input.FromDate);
                cryRpt.SetParameterValue("toDate", string.IsNullOrEmpty(input.ToDate) ? "---" : input.ToDate);
                Session["DocumentRpt"] = cryRpt;

                var jsonResult = Json(dataConverted, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;

            }

            return Json(false, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<JsonResult> PrintTax2Reports(GetTaxReportData2InputHelper input)
        {
            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetTaxReportData2", RestSharp.Method.GET, input.ToString());
            var lang = Request.Cookies["Lang"].Value;

            if (response.success)
            {
                var dataConverted = Helper<List<GetTaxReportDataOutput2Helper>>.Convert(JsonConvert.SerializeObject(response.result));
                var path = lang == "en-US" ? Server.MapPath("~/ReportsEn/rptTaxReport2_En.rpt"): Server.MapPath("~/Reports/rptTaxReport2.rpt");
                ReportDocument cryRpt = new ReportDocument();
                cryRpt.Load(path);
                cryRpt.SetDataSource(dataConverted);
                cryRpt.SetParameterValue("title", ERP.ResourcePack.Accounts.ReportsAccounts.TaxOutput);
                cryRpt.SetParameterValue("fromDate", string.IsNullOrEmpty(input.FromDate) ? "---" : input.FromDate);
                cryRpt.SetParameterValue("toDate", string.IsNullOrEmpty(input.ToDate) ? "---" : input.ToDate);
                cryRpt.SetParameterValue("customerName", string.IsNullOrEmpty(input.CustomerName) ? "---" : input.CustomerName);
                Session["DocumentRpt"] = cryRpt;

                var jsonResult = Json(dataConverted, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }

    }
}