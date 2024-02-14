using CrystalDecisions.CrystalReports.Engine;
using ERP._System.__ReportsAids.Input;
using ERP.Front.Helpers.Core;
using ERP.Web.UI.Models.ReportModels;
using ERP.WebUI.Controllers.Base;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ERP.Web.UI.Controllers.AidModule
{
    public class ReportsAidsController : BaseController
    {
        public ReportsAidsController() : base("ReportsAids", string.Empty) { }

        public ActionResult ScCommitteesCheckReport() => View();

        public ActionResult SCCasesListReport() => View();

        [HttpPost]
        public async Task<JsonResult> PrintReportsAids(rptScPortalAidsPerNationalityHelperInput input)
        {
            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetrptScPortalAidsPerNationality", RestSharp.Method.GET, input.ToString());

            if (response.success)
            {
                var dataConverted = Helper<List<Models.ReportModels.rptrptScPortalAidsPerNationalityOutput>>.Convert(JsonConvert.SerializeObject(response.result));

                var path = input.Lang == "en-US" ? Server.MapPath("~/Reports/rptReportsAids.rpt") : Server.MapPath("~/Reports/rptReportsAids.rpt");

                ReportDocument cryRpt = new ReportDocument();
                cryRpt.Load(path);
                cryRpt.SetDataSource(dataConverted);

                cryRpt.SetParameterValue("title", "ايرادات الوحدات العقارية");
                cryRpt.SetParameterValue("NationalityLkpIdtxt", string.IsNullOrEmpty(input.NationalityLkpIdtxt) ? "" : input.NationalityLkpIdtxt);
                cryRpt.SetParameterValue("FromDate", string.IsNullOrEmpty(input.FromDate) ? "" : input.FromDate);
                cryRpt.SetParameterValue("ToDate", string.IsNullOrEmpty(input.ToDate) ? "" : input.ToDate);

                Session["DocumentRpt"] = cryRpt;
                return Json(dataConverted, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public async Task<JsonResult> PrintScCommitteesCheckReport(RptScPortalAidsInputHelper input)
        {
            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetRptScPortalAids", RestSharp.Method.GET, input.ToString());

            if (response.success)
            {
                var dataConverted = Helper<List<RptScPortalAidsOutput>>.Convert(JsonConvert.SerializeObject(response.result));

                var path = input.Lang == "en-US" ? Server.MapPath("~/Reports/rptRptScPortalAids.rpt") : Server.MapPath("~/Reports/rptRptScPortalAids.rpt");

                ReportDocument cryRpt = new ReportDocument();
                cryRpt.Load(path);
                cryRpt.SetDataSource(dataConverted);

                cryRpt.SetParameterValue("title", "");
                cryRpt.SetParameterValue("FromDate", string.IsNullOrEmpty(input.FromDate) ? string.Empty : input.FromDate);
                cryRpt.SetParameterValue("ToDate", string.IsNullOrEmpty(input.ToDate) ? string.Empty : input.ToDate);
                cryRpt.SetParameterValue("RequestType", string.IsNullOrEmpty(input.ToDate) ? string.Empty : input.ToDate);
                cryRpt.SetParameterValue("CityLkp", string.IsNullOrEmpty(input.ToDate) ? string.Empty : input.ToDate);

                Session["DocumentRpt"] = cryRpt;
                return Json(dataConverted, JsonRequestBehavior.AllowGet);
            }

            return Json(false, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<JsonResult> PrintSCCasesList(GeSCCasesListScreenDataInputHelper input)
        {
            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetSCCasesListScreenData", RestSharp.Method.GET, input.ToString());

            if (response.success)
            {
                var dataConverted = Helper<List<Models.ReportModels.rptGeSCCasesListScreenDataOutput>>.Convert(JsonConvert.SerializeObject(response.result));

                var path = input.Lang == "en-US" ? Server.MapPath("~/Reports/rptSCCasesList.rpt") : Server.MapPath("~/Reports/rptSCCasesList.rpt");

                ReportDocument cryRpt = new ReportDocument();
                cryRpt.Load(path);
                cryRpt.SetDataSource(dataConverted);

                cryRpt.SetParameterValue("title", "قائمة الحالات");
                cryRpt.SetParameterValue("NationalityLkpIdtxt", string.IsNullOrEmpty(input.NationalityLkpIdtxt) ? "" : input.NationalityLkpIdtxt);
                cryRpt.SetParameterValue("CityLkpIdtxt", string.IsNullOrEmpty(input.CityLkpIdtxt) ? "" : input.CityLkpIdtxt);
                cryRpt.SetParameterValue("IdNumber", string.IsNullOrEmpty(input.IdNumber) ? "" : input.IdNumber);

                Session["DocumentRpt"] = cryRpt;
                return Json(dataConverted, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }

    }
}