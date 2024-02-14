using CrystalDecisions.CrystalReports.Engine;
using ERP._System.__ReportsSales.Input;
using ERP.Front.Helpers.Core;
using ERP.Web.UI.Models.ReportModels;
using ERP.WebUI.Controllers.Base;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ERP.Web.UI.Controllers.Sales
{
    public class ReportsSalesController : BaseController
    {

        public ReportsSalesController() : base("ReportsSales", string.Empty) { }


        public ActionResult ArJobCards() => View();

        public ActionResult ArJobCardsDetails() => View();


        [HttpPost]
        public async Task<JsonResult> PrintArJobCards(ArJobCardHelperInput input)
        {
            try
            {
                var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetArJobCards", RestSharp.Method.GET, input.ToString());

                if (response.success)
                {
                    var dataConverted = Helper<List<ArJobCardOutput>>.Convert(JsonConvert.SerializeObject(response.result));

                    var path = input.Lang == "en-US" ? Server.MapPath("~/ReportsEn/rptArJobCards_En.rpt") : Server.MapPath("~/Reports/rptArJobCards_Ar.rpt");

                    ReportDocument cryRpt = new ReportDocument();
                    cryRpt.Load(path);
                    cryRpt.SetDataSource(dataConverted);

                    cryRpt.SetParameterValue("title", ERP.ResourcePack.Sales.ReportsSales.Title);
                    cryRpt.SetParameterValue("FromDate", input.FromDate??"---");
                    cryRpt.SetParameterValue("ToDate", input.ToDate??"---");
                    cryRpt.SetParameterValue("Status", input.StatusLkpIdtxt??"---");
                    cryRpt.SetParameterValue("JobNumber", input.JobNumberLkpIdtxt??"---");
                    cryRpt.SetParameterValue("CustomerName", input.ArCustomerLkpIdtxt??"---");
                    Session["DocumentRpt"] = cryRpt;
                    return Json(dataConverted, JsonRequestBehavior.AllowGet); 
                }
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch (System.Exception ex)
            {

                throw;
            }
                      
        }


        [HttpPost]
        public async Task<JsonResult> PrintArJobCardsDetails(ArJobCardDetailsHelperInput input)
        {
            try
            {
                var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetArJobCardsDetails", RestSharp.Method.GET, input.ToString());

                if (response.success)
                {
                    var dataConverted = Helper<List<ArJobCardDetailsOutput>>.Convert(JsonConvert.SerializeObject(response.result));

                    var path = input.Lang == "en-US" ? Server.MapPath("~/ReportsEn/rptArJobCardsDetails_En.rpt") : Server.MapPath("~/Reports/rptArJobCardsDetails.rpt");

                    ReportDocument cryRpt = new ReportDocument();
                    cryRpt.Load(path);
                    cryRpt.SetDataSource(dataConverted);

                    cryRpt.SetParameterValue("title", ERP.ResourcePack.Sales.ReportsSales.ArJobCardDetails);
                    cryRpt.SetParameterValue("FromDate", input.FromDate ?? "---");
                    cryRpt.SetParameterValue("ToDate", input.ToDate ?? "---");
                    cryRpt.SetParameterValue("Status", input.StatusLkpIdtxt ?? "---");
                    cryRpt.SetParameterValue("JobNumber", input.JobNumberLkpIdtxt ?? "---");
                    cryRpt.SetParameterValue("CustomerName", input.ArCustomerLkpIdtxt ?? "---");
                    Session["DocumentRpt"] = cryRpt;
                    return Json(dataConverted, JsonRequestBehavior.AllowGet);
                }
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch (System.Exception ex)
            {

                throw;
            }

        }
    }
}