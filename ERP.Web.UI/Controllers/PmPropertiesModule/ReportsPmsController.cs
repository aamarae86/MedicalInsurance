using CrystalDecisions.CrystalReports.Engine;
using ERP._System.__ReportsPms.Input;
using ERP.Front.Helpers.Core;
using ERP.Front.Helpers.DataTableHelpers;
using ERP.Front.Helpers.Parameters;
using ERP.Web.UI.Models.ReportModels;
using ERP.Web.UI.Models.ResultModels;
using ERP.WebUI.Controllers.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ERP.Web.UI.Controllers.PmPropertiesModule
{
    public class ReportsPmsController : BaseController
    {
        public ReportsPmsController() : base("ReportsPms", string.Empty) { }

        public ActionResult PmContractNotRenewed() => View();

        public ActionResult PmContracts() => View();

        public ActionResult TenantAccount() => View();

        public ActionResult PropertiesRevenue() => View();

        [HttpPost]
        public async Task<JsonResult> PrintPropertiesRevenue(rptPmPropertiesIncomeHelperInput input)
        {
            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetrptPmPropertiesIncome", RestSharp.Method.GET, input.ToString());

            if (response.success)
            {
                var dataConverted = Helper<List<Models.ReportModels.rptrptPmPropertiesIncomeOutput>>.Convert(JsonConvert.SerializeObject(response.result));

                var path = input.Lang == "en-US" ? Server.MapPath("~/ReportsEn/rptPropertiesRevenue_En.rpt") : Server.MapPath("~/Reports/rptPropertiesRevenue.rpt");

                ReportDocument cryRpt = new ReportDocument();
                cryRpt.Load(path);
                cryRpt.SetDataSource(dataConverted);

                cryRpt.SetParameterValue("title", ERP.ResourcePack.PmPropertiesModule.Reports.rptPropertiesRevenueTitle);
                cryRpt.SetParameterValue("PropertyIdtxt", string.IsNullOrEmpty(input.PropertyIdtxt) ? "" : input.PropertyIdtxt);
                cryRpt.SetParameterValue("PropertyIdNumber", string.IsNullOrEmpty(input.PropertyIdNumber) ? "" : input.PropertyIdNumber);
                cryRpt.SetParameterValue("PmOwnerIdtxt", string.IsNullOrEmpty(input.PmOwnerIdtxt) ? "" : input.PmOwnerIdtxt);
                cryRpt.SetParameterValue("PmOwnerIdNumber", string.IsNullOrEmpty(input.PmOwnerIdNumber) ? "" : input.PmOwnerIdNumber);
                cryRpt.SetParameterValue("PmUnitTypeLkpIdtxt", string.IsNullOrEmpty(input.PmUnitTypeLkpIdtxt) ? "" : input.PmUnitTypeLkpIdtxt);
                cryRpt.SetParameterValue("FromDate", string.IsNullOrEmpty(input.FromDate) ? "" : input.FromDate);
                cryRpt.SetParameterValue("ToDate", string.IsNullOrEmpty(input.ToDate) ? "" : input.ToDate);
                cryRpt.SetParameterValue("PeriodsYearIdtxt", string.IsNullOrEmpty(input.PeriodsYearIdtxt) ? "" : input.PeriodsYearIdtxt);

                Session["DocumentRpt"] = cryRpt;
                return Json(dataConverted, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<JsonResult> PrintTenantAccount(rptArDebitCreditHelperInput input)
        {
            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetrptArDebitCredit", RestSharp.Method.GET, input.ToString());

            if (response.success)
            {
                var dataConverted = Helper<List<Models.ReportModels.rptArDebitCreditOutputrpt>>.Convert(JsonConvert.SerializeObject(response.result));

                var path = input.Lang == "en-US" ? Server.MapPath("~/ReportsEn/rptTenantAccount_En.rpt") : Server.MapPath("~/Reports/rptTenantAccount.rpt");
                var excludePaid = input.Lang == "en-US" ? "Excluded Paid" : "المدفوعة المستبعدة";

                ReportDocument cryRpt = new ReportDocument();
                cryRpt.Load(path);
                cryRpt.SetDataSource(dataConverted);

                cryRpt.SetParameterValue("title", ERP.ResourcePack.PmPropertiesModule.Reports.CustomerAccountStmt);
                cryRpt.SetParameterValue("Customertxt", string.IsNullOrEmpty(input.Customertxt) ? "" : input.Customertxt);
                cryRpt.SetParameterValue("CustomerNumber", string.IsNullOrEmpty(input.CustomerNumber) ? "" : input.CustomerNumber);
                cryRpt.SetParameterValue("FromDate", string.IsNullOrEmpty(input.FromDate) ? "" : input.FromDate);
                cryRpt.SetParameterValue("ToDate", string.IsNullOrEmpty(input.ToDate) ? "" : input.ToDate);
                cryRpt.SetParameterValue("ExcludePaid", (input.IsNotSettled) ? excludePaid : " ");

                Session["DocumentRpt"] = cryRpt;
                return Json(dataConverted, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<JsonResult> PrintPmList(PmPropertiesUnitsUnoccupiedHelperInput input)
        {
            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetPmPropertiesUnitsUnoccupied", RestSharp.Method.GET, input.ToString());

            if (response.success)
            {
                var dataConverted = Helper<List<Models.ReportModels.rptPmPropertiesUnitsUnoccupiedOutput>>.Convert(JsonConvert.SerializeObject(response.result));

                var path = input.Lang == "en-US" ? Server.MapPath("~/ReportsEn/rptReportsPms_En.rpt") : Server.MapPath("~/Reports/rptReportsPms.rpt");

                ReportDocument cryRpt = new ReportDocument();
                cryRpt.Load(path);
                cryRpt.SetDataSource(dataConverted);

                cryRpt.SetParameterValue("title", ERP.ResourcePack.PmPropertiesModule.Reports.rptReportsPmsTitle);
                cryRpt.SetParameterValue("PropertyIdtxt", string.IsNullOrEmpty(input.PropertyIdtxt) ? "" : input.PropertyIdtxt);
                cryRpt.SetParameterValue("OwnerIdtxt", string.IsNullOrEmpty(input.OwnerIdtxt) ? "" : input.OwnerIdtxt);
                cryRpt.SetParameterValue("PmUnitTypeLkpIdtxt", string.IsNullOrEmpty(input.PmUnitTypeLkpIdtxt) ? "" : input.PmUnitTypeLkpIdtxt);

                Session["DocumentRpt"] = cryRpt;
                return Json(dataConverted, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<JsonResult> PrintPmContractNotRenewed(PmContractNotRenewedHelperInput input)
        {
            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetPmContractNotRenewed", RestSharp.Method.GET, input.ToString());

            if (response.success)
            {
                var dataConverted = Helper<List<Models.ReportModels.rptPmContractNotRenewedOutput>>.Convert(JsonConvert.SerializeObject(response.result));

                var path = input.Lang == "en-US" ? Server.MapPath("~/ReportsEn/rptPmContractNotRenewed_En.rpt") : Server.MapPath("~/Reports/rptPmContractNotRenewed.rpt");

                ReportDocument cryRpt = new ReportDocument();
                cryRpt.Load(path);
                cryRpt.SetDataSource(dataConverted);

                cryRpt.SetParameterValue("title", ERP.ResourcePack.PmPropertiesModule.Reports.rptPmContractNotRenewed);
                cryRpt.SetParameterValue("PropertyIdtxt", string.IsNullOrEmpty(input.PropertyIdtxt) ? "" : input.PropertyIdtxt);
                cryRpt.SetParameterValue("PMTenantIdtxt", string.IsNullOrEmpty(input.PMTenantIdtxt) ? "" : input.PMTenantIdtxt);
                cryRpt.SetParameterValue("PmUnitTypeLkpIdtxt", string.IsNullOrEmpty(input.PmUnitTypeLkpIdtxt) ? "" : input.PmUnitTypeLkpIdtxt);

                Session["DocumentRpt"] = cryRpt;
                return Json(dataConverted, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<JsonResult> PrintPmContracts(PmContractsHelperInput input)
        {
            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetPmContracts", RestSharp.Method.GET, input.ToString());

            if (response.success)
            {
                var dataConverted = Helper<List<rptPmContractsOutput>>.Convert(JsonConvert.SerializeObject(response.result));

                var path = input.Lang == "en-US" ? Server.MapPath("~/ReportsEn/rptPmContracts_En.rpt") : Server.MapPath("~/Reports/rptPmContracts.rpt");

                ReportDocument cryRpt = new ReportDocument();
                cryRpt.Load(path);
                cryRpt.SetDataSource(dataConverted);

                cryRpt.SetParameterValue("title", ERP.ResourcePack.PmPropertiesModule.Reports.rptPmContracts);
                cryRpt.SetParameterValue("PropertyIdtxt", string.IsNullOrEmpty(input.PropertyIdtxt) ? "" : input.PropertyIdtxt);
                cryRpt.SetParameterValue("PMTenantIdtxt", string.IsNullOrEmpty(input.PMTenantIdtxt) ? "" : input.PMTenantIdtxt);
                cryRpt.SetParameterValue("PmUnitTypeLkpIdtxt", string.IsNullOrEmpty(input.PmUnitTypeLkpIdtxt) ? "" : input.PmUnitTypeLkpIdtxt);
                cryRpt.SetParameterValue("PmActivityIdtxt", string.IsNullOrEmpty(input.PmActivityIdtxt) ? "" : input.PmActivityIdtxt);
                cryRpt.SetParameterValue("StatusLKkpIdtxt", string.IsNullOrEmpty(input.StatusLKkpIdtxt) ? "" : input.StatusLKkpIdtxt);
                cryRpt.SetParameterValue("contractEndDate", string.IsNullOrEmpty(input.contractEndDate) ? "" : input.contractEndDate);
                cryRpt.SetParameterValue("ContractStartDate", string.IsNullOrEmpty(input.ContractStartDate) ? "" : input.ContractStartDate);
                cryRpt.SetParameterValue("FromDate", string.IsNullOrEmpty(input.FromDate) ? "" : input.FromDate);
                cryRpt.SetParameterValue("ToDate", string.IsNullOrEmpty(input.ToDate) ? "" : input.ToDate);

                Session["DocumentRpt"] = cryRpt;
                return Json(dataConverted, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }




        public async Task<ActionResult> TenantAccountGrid(rptArDebitCreditHelperInputSearchVM searchParms)
        {
            
            try
            {
                var dtParms = DataTableParmsHelper.GetParms(Request.Form);

                var parameters = new GetAllPagedAndSortedWithParams<rptArDebitCreditHelperInputSearchVM>()
                {
                    Params = searchParms,
                    Sorting = dtParms.sort.PairAsSqlExpression,
                    OrderByValue = dtParms.sort,
                    MaxResultCount = dtParms.pageSize,
                    SkipCount = dtParms.skip
                };

                var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetTenantAccountGrid", RestSharp.Method.GET, parameters);

                var dataConverted = Helper<ListResultBaseWithTotalRecords<rptArDebitCreditVM>>.Convert(JsonConvert.SerializeObject(response.result));

                int recordsTotal = dataConverted?.totalCount ?? 0;
                var data = dataConverted?.Items ?? new List<rptArDebitCreditVM>();

                return Json(new { dtParms.draw, recordsFiltered = recordsTotal, recordsTotal, data }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}