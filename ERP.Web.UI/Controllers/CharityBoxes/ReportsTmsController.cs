using CrystalDecisions.CrystalReports.Engine;
using ERP._System.__ReportsTms.Inputs;
using ERP.Front.Helpers.Core;
using ERP.WebUI.Controllers.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ERP.Web.UI.Controllers.CharityBoxes
{
    public class ReportsTmsController : BaseController
    {
        public ReportsTmsController() : base("TmCharityBoxList", string.Empty) { }
        [HttpPost]
        public async Task<JsonResult> PrintTmCharityBoxList(TmCharityBoxListScreenDataHelperInput input)
        {
            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetTmCharityBoxListScreenData", RestSharp.Method.GET, input.ToString());

            if (response.success)
            {
                var dataConverted = Helper<List<Models.ReportModels.TmCharityBoxListOutput>>.Convert(JsonConvert.SerializeObject(response.result));

                var path = input.Lang == "en-US" ? Server.MapPath("~/Reports/rptTmCharityBoxList.rpt") : Server.MapPath("~/Reports/rptTmCharityBoxList.rpt");

                ReportDocument cryRpt = new ReportDocument();
                cryRpt.Load(path);
                cryRpt.SetDataSource(dataConverted);

                cryRpt.SetParameterValue("title", "قائمة الحصالات");
                cryRpt.SetParameterValue("CharityId", string.IsNullOrEmpty(input.CharityIdtxt) ? "" : input.CharityIdtxt);
                cryRpt.SetParameterValue("CharityBoxBarcode", string.IsNullOrEmpty(input.CharityBoxBarcode) ? "" : input.CharityBoxBarcode);
                cryRpt.SetParameterValue("CharityStatus", string.IsNullOrEmpty(input.CharityStatustxt) ? "" : input.CharityStatustxt);
                cryRpt.SetParameterValue("BoxTypeName", string.IsNullOrEmpty(input.BoxTypeNametxt) ? "" : input.BoxTypeNametxt);
                cryRpt.SetParameterValue("CityId", string.IsNullOrEmpty(input.CityIdtxt) ? "" : input.CityIdtxt);
                cryRpt.SetParameterValue("RegionId", string.IsNullOrEmpty(input.RegionIdtxt) ? "" : input.RegionIdtxt);
                cryRpt.SetParameterValue("LocationId", string.IsNullOrEmpty(input.LocationIdtxt) ? "" : input.LocationIdtxt);
                cryRpt.SetParameterValue("LocationSubId", string.IsNullOrEmpty(input.LocationSubIdtxt) ? "" : input.LocationSubIdtxt);

                Session["DocumentRpt"] = cryRpt;
                return Json(dataConverted, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }
    }
}