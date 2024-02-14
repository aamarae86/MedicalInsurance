using CrystalDecisions.CrystalReports.Engine;
using ERP._System.__AccountModule._ApPdcInterface.ProcDto;
using ERP._System.__ReportsAccounts.Inputs;
using ERP.Authorization;
using ERP.Front.Helpers.Core;
using ERP.Front.Helpers.DataTableHelpers;
using ERP.Front.Helpers.Parameters;
using ERP.Front.Helpers.Repository;
using ERP.Web.UI.Models.ResultModels;
using ERP.Web.UI.Models.ViewModels.Reports;
using ERP.Web.UI.Models.ViewModels.Sales;
using ERP.WebUI.Controllers.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ERP.Web.UI.Controllers.Reports
{
    public class ReportsController : BaseController
    {
        public ReportsController() : base("ItemMovements", PermissionNames.Pages_IvSaleHd)
        {
        }

        // GET: Reports
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ItemMovements()
        {
            return View();
        }

        public ActionResult VendorItemsReport()
        {
            return View();
        }

        public async Task<ActionResult> VendorItemsFilters(VendorItemsSearchVM searchParms)
        {
            string baseurl = _apiAppService.Replace("ItemMovements", "VendorItems");
            try
            {
                var dtParms = DataTableParmsHelper.GetParms(Request.Form);

                var parameters = new GetAllPagedAndSortedWithParams<VendorItemsSearchVM>()
                {
                    Params = searchParms,
                    Sorting = dtParms.sort.PairAsSqlExpression,
                    OrderByValue = dtParms.sort,
                    MaxResultCount = dtParms.pageSize,
                    SkipCount = dtParms.skip
                };

                var response = await _restClientContainer.SendRequest<RestResult>($"{baseurl}/GetItemMovementsForVendor", RestSharp.Method.GET, parameters);

                var dataConverted = Helper<ListResultBaseWithTotalRecords<VendorItemsVM>>.Convert(JsonConvert.SerializeObject(response.result));

                int recordsTotal = dataConverted?.totalCount ?? 0;
                var data = dataConverted?.Items ?? new List<VendorItemsVM>();

                return Json(new { dtParms.draw, recordsFiltered = recordsTotal, recordsTotal, data }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw;
            }
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
    
    public async Task<ActionResult> Search(ItemMovementsSearchVM searchParms)
        {
            try
            {
                var dtParms = DataTableParmsHelper.GetParms(Request.Form);

                var parameters = new GetAllPagedAndSortedWithParams<ItemMovementsSearchVM>()
                {
                    Params = searchParms,
                    Sorting = dtParms.sort.PairAsSqlExpression,
                    OrderByValue = dtParms.sort,
                    MaxResultCount = dtParms.pageSize,
                    SkipCount = dtParms.skip
                };

                var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetItemMovements", RestSharp.Method.GET, parameters);

                var dataConverted = Helper<ListResultBaseWithTotalRecords<ItemMovementsVM>>.Convert(JsonConvert.SerializeObject(response.result));

                int recordsTotal = dataConverted?.totalCount ?? 0;
                var data = dataConverted?.Items ?? new List<ItemMovementsVM>();

                return Json(new { dtParms.draw, recordsFiltered = recordsTotal, recordsTotal, data }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        #region ItemQtyPerWarehouse
        public ActionResult ItemQtyPerWarehouse()
        {
            return View();
        }
        #endregion


        #region rptIvItemStock
        public ActionResult ItemStockReport()
        {
            return View();
        }
        public async Task<ActionResult> ItemStockSearch(ItemStockSearchVM searchParms)
        {
            try
            {
                var dtParms = DataTableParmsHelper.GetParms(Request.Form);

                var parameters = new GetAllPagedAndSortedWithParams<ItemStockSearchVM>()
                {
                    Params = searchParms,
                    Sorting = dtParms.sort.PairAsSqlExpression,
                    OrderByValue = dtParms.sort,
                    MaxResultCount = dtParms.pageSize,
                    SkipCount = dtParms.skip
                };

                var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetItemStock", RestSharp.Method.GET, parameters);

                var dataConverted = Helper<ListResultBaseWithTotalRecords<ItemStockVM>>.Convert(JsonConvert.SerializeObject(response.result));

                int recordsTotal = dataConverted?.totalCount ?? 0;
                var data = dataConverted?.Items ?? new List<ItemStockVM>();

                return Json(new { dtParms.draw, recordsFiltered = recordsTotal, recordsTotal, data }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
        #region rptIvItemSalesMonthlyAnalysis
        public ActionResult ItemSalesMonthlyAnalysisReport()
        {
            return View();
        }
        public async Task<ActionResult> ItemSalesMonthlyAnalysisSearch(ItemSalesMonthlyAnalysisSearchVM searchParms)
        {
            string baseurl = _apiAppService.Replace("ItemMovements", "ItemSalesMonthlyAnalysis");
            try
            {
                var dtParms = DataTableParmsHelper.GetParms(Request.Form);

                var parameters = new GetAllPagedAndSortedWithParams<ItemSalesMonthlyAnalysisSearchVM>()
                {
                    Params = searchParms,
                    Sorting = dtParms.sort.PairAsSqlExpression,
                    OrderByValue = dtParms.sort,
                    MaxResultCount = dtParms.pageSize,
                    SkipCount = dtParms.skip
                };

                var response = await _restClientContainer.SendRequest<RestResult>($"{baseurl}/GetItemSalesMonthlyAnalysis", RestSharp.Method.GET, parameters);

                var dataConverted = Helper<ListResultBaseWithTotalRecords<ItemSalesMonthlyAnalysisVM>>.Convert(JsonConvert.SerializeObject(response.result));

                int recordsTotal = dataConverted?.totalCount ?? 0;
                var data = dataConverted?.Items ?? new List<ItemSalesMonthlyAnalysisVM>();

                return Json(new { dtParms.draw, recordsFiltered = recordsTotal, recordsTotal, data }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
        #region rptIvItemSalesAnalysis
        public ActionResult ItemSalesAnalysisReport()
        {
            return View();
        }
        public async Task<ActionResult> ItemSalesAnalysisReportSearch(ItemSalesAnalysisSearchVM searchParms)
        {
            string baseurl = _apiAppService.Replace("ItemMovements", "ItemSalesAnalysis");
            try
            {
                var dtParms = DataTableParmsHelper.GetParms(Request.Form);

                var parameters = new GetAllPagedAndSortedWithParams<ItemSalesAnalysisSearchVM>()
                {
                    Params = searchParms,
                    Sorting = dtParms.sort.PairAsSqlExpression,
                    OrderByValue = dtParms.sort,
                    MaxResultCount = dtParms.pageSize,
                    SkipCount = dtParms.skip
                };

                var response = await _restClientContainer.SendRequest<RestResult>($"{baseurl}/GetItemSalesAnalysis", RestSharp.Method.GET, parameters);

                var dataConverted = Helper<ListResultBaseWithTotalRecords<ItemSalesAnalysisVM>>.Convert(JsonConvert.SerializeObject(response.result));

                int recordsTotal = dataConverted?.totalCount ?? 0;
                var data = dataConverted?.Items ?? new List<ItemSalesAnalysisVM>();

                return Json(new { dtParms.draw, recordsFiltered = recordsTotal, recordsTotal, data }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
        public ActionResult Test()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Testrpt(int Id)
        {
           
            var path = Server.MapPath("Test.rpt");
            ReportDocument cryRpt = new ReportDocument();
            cryRpt.Load(path);
            //cryRpt.SetDataSource(data);

            cryRpt.SetParameterValue("title", "test");

            Session["DocumentRpt"] = cryRpt;

            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}