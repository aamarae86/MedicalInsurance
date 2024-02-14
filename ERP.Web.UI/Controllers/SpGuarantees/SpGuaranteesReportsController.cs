using CrystalDecisions.CrystalReports.Engine;
using ERP._System.__AccountModule._ApPdcInterface.ProcDto;
using ERP._System.__ReportsAccounts.Inputs;
using ERP._System.__SpGuaranteesReports.Inputs;
using ERP.Front.Helpers.Core;
using ERP.Web.UI.Models.ReportModels;
using ERP.Web.UI.Models.ViewModels.SpGuarantees;
using ERP.WebUI.Controllers.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ERP.Web.UI.Controllers.SpGuarantees
{
    public class SpGuaranteesReportsController : BaseController
    {
        public SpGuaranteesReportsController() : base("SpGuaranteesReports", string.Empty) { }
        public ActionResult SpCaseList() => View();

        public ActionResult Sponsoredare18() => View();

        public ActionResult rptApDebitCredit() => View();
        public ActionResult CaseOperation(string typeid)
        {
            if (string.IsNullOrEmpty(typeid)) return RedirectToAction("Index", "Home");

            ViewData["TYPE_ID"] = CipherStringController.Decrypt(typeid);

            return View();
        }

        [HttpPost]
        public async Task<JsonResult> PrintSpCaseOperationReport(SpCaseOperationReportVM input)
        {
            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetCaseOperationsDataList", RestSharp.Method.GET, input.SpCaseOperationsDataListInput.ToString());

            if (response.success)
            {
                var dataConverted = Helper<List<Models.ReportModels.SpCaseOperationsDataListOutput>>.Convert(JsonConvert.SerializeObject(response.result));

                string path = string.Empty;

                if (input.SpCaseOperationsDataListInput.TypeId == 711 || input.SpCaseOperationsDataListInput.TypeId == 710)
                {
                    path = input.SpCaseOperationsDataListInput.Lang == "en-US" ? Server.MapPath("~/Reports/rptSpCaseOperationsCanStp.rpt") : Server.MapPath("~/Reports/rptSpCaseOperationsCanStp.rpt");
                }

                if (input.SpCaseOperationsDataListInput.TypeId == 724)
                {
                    path = input.SpCaseOperationsDataListInput.Lang == "en-US" ? Server.MapPath("~/Reports/rptSpCaseOperationsChange.rpt") : Server.MapPath("~/Reports/rptSpCaseOperationsChange.rpt");
                }

                ReportDocument cryRpt = new ReportDocument();
                cryRpt.Load(path);
                cryRpt.SetDataSource(dataConverted);
                if (input.SpCaseOperationsDataListInput.TypeId == 711)
                {
                    cryRpt.SetParameterValue("title", "قائمه المكفولين الملغيه");
                }
                if (input.SpCaseOperationsDataListInput.TypeId == 710)
                {
                    cryRpt.SetParameterValue("title", "قائمه المكفولين المتوقفه");
                }
                if (input.SpCaseOperationsDataListInput.TypeId == 724)
                {
                    cryRpt.SetParameterValue("title", "قائمه الاستبدالات");
                    cryRpt.SetParameterValue("NewCaseNo", string.IsNullOrEmpty(input.CaseInfo.NewCaseNumber) ? "" : input.CaseInfo.NewCaseNumber);
                    cryRpt.SetParameterValue("NewCaseName", string.IsNullOrEmpty(input.CaseInfo.NewCaseName) ? "" : input.CaseInfo.NewCaseName);
                }

                cryRpt.SetParameterValue("From", string.IsNullOrEmpty(input.SpCaseOperationsDataListInput.FromDate) ? "" : input.SpCaseOperationsDataListInput.FromDate);
                cryRpt.SetParameterValue("To", string.IsNullOrEmpty(input.SpCaseOperationsDataListInput.ToDate) ? "" : input.SpCaseOperationsDataListInput.ToDate);
                cryRpt.SetParameterValue("CaseNo", string.IsNullOrEmpty(input.CaseInfo.CaseNumber) ? "" : input.CaseInfo.CaseNumber);
                cryRpt.SetParameterValue("CaseName", string.IsNullOrEmpty(input.CaseInfo.CaseName) ? "" : input.CaseInfo.CaseName);
                cryRpt.SetParameterValue("BenNo", string.IsNullOrEmpty(input.CaseInfo.BeneficentNumber) ? "" : input.CaseInfo.BeneficentNumber);
                cryRpt.SetParameterValue("BenName", string.IsNullOrEmpty(input.CaseInfo.BeneficentName) ? "" : input.CaseInfo.BeneficentName);

                Session["DocumentRpt"] = cryRpt;

                return Json(dataConverted, JsonRequestBehavior.AllowGet);
            }

            return Json(false, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<JsonResult> PrintSpCaseListReport(GetSpCaseListrptVM input)
        {
            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetIGetSpCaseListrpt", RestSharp.Method.GET, input.ToString());

            if (response.success)
            {
                var dataConverted = Helper<List<GetSpCaseListrptOutputrpt>>.Convert(JsonConvert.SerializeObject(response.result));

                string path = input.Lang == "en-US" ? Server.MapPath("~/Reports/rptSpCaseList.rpt") : Server.MapPath("~/Reports/rptSpCaseList.rpt");


                ReportDocument cryRpt = new ReportDocument();
                cryRpt.Load(path);
                cryRpt.SetDataSource(dataConverted);
                cryRpt.SetParameterValue("title", "قائمه المكفولين");
                cryRpt.SetParameterValue("CaseName", string.IsNullOrEmpty(input.CaseName) ? "" : input.CaseName);
                cryRpt.SetParameterValue("CaseNo", string.IsNullOrEmpty(input.CaseNumber) ? "" : input.CaseNumber);
                cryRpt.SetParameterValue("BenName", string.IsNullOrEmpty(input.SpBeneficentName) ? "" : input.SpBeneficentName);
                cryRpt.SetParameterValue("BenNo", string.IsNullOrEmpty(input.SpBeneficentNumber) ? "" : input.SpBeneficentNumber);
                cryRpt.SetParameterValue("StatuesName", string.IsNullOrEmpty(input.StatuesName) ? "" : input.StatuesName);

                Session["DocumentRpt"] = cryRpt;

                return Json(dataConverted, JsonRequestBehavior.AllowGet);
            }

            return Json(false, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<JsonResult> PrintSponsoredare18Report(GetSpCaseListUpTo18YearrptHelperInput input)
        {
            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetSpCaseListUpTo18Yearrpt", RestSharp.Method.GET, input.ToString());

            if (response.success)
            {
                var dataConverted = Helper<List<rptGetSpCaseListUpTo18YearrptOutput>>.Convert(JsonConvert.SerializeObject(response.result));

                string path = input.Lang == "en-US" ? Server.MapPath("~/Reports/rptGetSpCaseListUpTo18Yearrpt.rpt") : Server.MapPath("~/Reports/rptGetSpCaseListUpTo18Yearrpt.rpt");


                ReportDocument cryRpt = new ReportDocument();
                cryRpt.Load(path);
                cryRpt.SetDataSource(dataConverted);
                cryRpt.SetParameterValue("title", "المكفولين عمر 18 سنة");
                cryRpt.SetParameterValue("SpBeneficentIdtxt", string.IsNullOrEmpty(input.SpBeneficentIdtxt) ? "" : input.SpBeneficentIdtxt);
                cryRpt.SetParameterValue("SponsorCategorytxt", string.IsNullOrEmpty(input.SponsorCategorytxt) ? "" : input.SponsorCategorytxt);
                cryRpt.SetParameterValue("SpBeneficentIdNum", string.IsNullOrEmpty(input.SpBeneficentIdNum) ? "" : input.SpBeneficentIdNum);

                Session["DocumentRpt"] = cryRpt;

                return Json(dataConverted, JsonRequestBehavior.AllowGet);
            }

            return Json(false, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<JsonResult> printrptApDebitCredit(VendorItemReportInput input)
        {
            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetrptApDebitCredit", RestSharp.Method.GET, input.ToString());

            if (response.success)
            {
                var dataConverted = Helper<List<GetVendorItemReportDataOutput>>.Convert(JsonConvert.SerializeObject(response.result));

                string path = input.Lang == "en-US" ? Server.MapPath("~/Reports/rptApDebitCredit.rpt") : Server.MapPath("~/Reports/rptApDebitCredit.rpt");


                ReportDocument cryRpt = new ReportDocument();
                cryRpt.Load(path);
                cryRpt.SetDataSource(dataConverted);
                cryRpt.SetParameterValue("VendorId", (input.VendorId));
                cryRpt.SetParameterValue("FromDate", string.IsNullOrEmpty(input.FromDate) ? "" : input.FromDate);
                cryRpt.SetParameterValue("ToDate", string.IsNullOrEmpty(input.ToDate) ? "" : input.ToDate);

                Session["DocumentRpt"] = cryRpt;

                return Json(dataConverted, JsonRequestBehavior.AllowGet);
            }

            return Json(false, JsonRequestBehavior.AllowGet);
        }
    }

    public class GetSpCaseListrptOutputrpt
    {
        public string CaseName { get; set; }
        public string CaseNumber { get; set; }
        public string BeneficentName { get; set; }
        public string BeneficentNumber { get; set; }
        public string SponsType { get; set; }
        public string StatuesName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Amount { get; set; }
    }

    public class SpCaseOperationReportVM
    {
        public SpCaseOperationsDataListInputHelper SpCaseOperationsDataListInput { get; set; }
        public CaseInfo CaseInfo { get; set; }
    }

    public class CaseInfo
    {
        public string CaseName { get; set; }
        public string CaseNumber { get; set; }

        public string NewCaseName { get; set; }
        public string NewCaseNumber { get; set; }

        public string BeneficentName { get; set; }
        public string BeneficentNumber { get; set; }

    }
}