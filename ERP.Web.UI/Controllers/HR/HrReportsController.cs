using CrystalDecisions.CrystalReports.Engine;
using ERP._System.__HrReports.Inputs;
using ERP.Front.Helpers.Core;
using ERP.WebUI.Controllers.Base;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ERP.Web.UI.Controllers.HR
{
    public class HrReportsController : BaseController
    {
        public HrReportsController() : base("HrReports", string.Empty) { }

        public ActionResult PyPayrollReport() => View();

        [HttpPost]
        public async Task<JsonResult> PrintPyPayrollReport(PyPayrollDetailsInputHelper input)
        {
            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetPyPayrollDetails", RestSharp.Method.GET, input.ToString());

            if (response.success)
            {
                var dataConverted = Helper<List<Models.ReportModels.PyPayrollDetailsOutput>>.Convert(JsonConvert.SerializeObject(response.result));

                var path = input.Lang == "en-US" ? Server.MapPath("~/ReportsEn/rptPyPayrollReport_En.rpt") : Server.MapPath("~/Reports/rptPyPayrollReport.rpt");

                ReportDocument cryRpt = new ReportDocument();
                cryRpt.Load(path);
                cryRpt.SetDataSource(dataConverted);

                cryRpt.SetParameterValue("title", ERP.ResourcePack.HR.HrReports.PyPayrollReportTitle);
                cryRpt.SetParameterValue("PeriodIdtxt", string.IsNullOrEmpty(input.PeriodIdtxt)?"":input.PeriodIdtxt);
                cryRpt.SetParameterValue("PyPayrollTypeIdtxt", string.IsNullOrEmpty(input.PyPayrollTypeIdtxt) ? "" : input.PyPayrollTypeIdtxt);

                Session["DocumentRpt"] = cryRpt;
                return Json(dataConverted, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }
    }
}