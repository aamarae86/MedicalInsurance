using CrystalDecisions.CrystalReports.Engine;
using ERP._System.__SalesModule._FndSalesMen.Dto;
using ERP._System.__SalesModule._IvSaleHd.Dto;
using ERP._System.PostRecords.Dto;
using ERP.Authorization;
using ERP.Front.Helpers.Core;
using ERP.Front.Helpers.DataTableHelpers;
using ERP.Front.Helpers.Parameters;
using ERP.Front.Helpers.Repository;
using ERP.Helpers.Core;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Models.ReportModels;
using ERP.Web.UI.Models.ResultModels;
using ERP.Web.UI.Models.ViewModels.Sales;
using ERP.WebUI.Controllers.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace ERP.Web.UI.Controllers.Sales
{
    public class IvSaleHdController : BaseController
    {
        // GET: IvSaleHd
        public IvSaleHdController() : base("IvSaleHd", PermissionNames.Pages_IvSaleHd_Insert) { }

        public PartialViewResult IvSaleHdSearch() => PartialView();

        public PartialViewResult IvSaleHdData() => PartialView();
        public PartialViewResult IvSaleHdHdDataDetail() => PartialView();

        public PartialViewResult IvSaleHdHdFormDetail(long? id, string trigger)
        {
            ViewBag.trigger = trigger;
            return PartialView();
        }

        public async Task<ActionResult> FormView(string id, string t)
        {
            
                var (allPermissions, insertPermission) = await GetMainPermissions();

                TempData["Permissions"] = allPermissions;

                ViewBag.trigger = CipherStringController.Decrypt(t);

                ViewData["Id"] = string.IsNullOrEmpty(id) ? null : CipherStringController.Decrypt(id);

                if (!string.IsNullOrEmpty(id))
                {
                    long decId = Convert.ToInt64(CipherStringController.Decrypt(id));

                    if (!allPermissions.Contains(PermissionNames.Pages_IvSaleHd_Update))
                        return RedirectToAction("Index", "Home", new { area = string.Empty });//

                var response2 = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetDetailAsync?Id={decId}", RestSharp.Method.GET);

                var obj = Helper<IvSaleHdVM>.Convert(JsonConvert.SerializeObject(response2.result));
                    ViewData["DetailAsync"] = obj;
                    ViewData["PaymentMethodLkpId"] = obj.PaymentMethodLkpId;
                }
                else
                {
                    if (!insertPermission.Contains(PermissionNames.Pages_IvSaleHd_Insert))
                        return RedirectToAction("Index", "Home", new { area = string.Empty });
                }

                return View();
            
           
        }

        public PartialViewResult IvSaleHdForm(long? id, string trigger, IvSaleHdVM IvSaleHdVM)
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

                return PartialView(IvSaleHdVM);
            }

            return PartialView();
        }



        public async Task<ActionResult> LoadDataGrid(IvSaleHdSearchDto searchParms)
        {
            try
            {
                var dtParms = DataTableParmsHelper.GetParms(Request.Form);

                var parameters = new GetAllPagedAndSortedWithParams<IvSaleHdSearchDto>()
                {
                    Params = searchParms,
                    Sorting = dtParms.sort.PairAsSqlExpression,
                    OrderByValue = dtParms.sort,
                    MaxResultCount = dtParms.pageSize,
                    SkipCount = dtParms.skip
                };

                var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetAll", RestSharp.Method.GET, parameters);

                var dataConverted = Helper<ListResultBaseWithTotalRecords<IvSaleHdVM>>.Convert(JsonConvert.SerializeObject(response.result));

                int recordsTotal = dataConverted?.totalCount ?? 0;
                var data = dataConverted?.Items ?? new List<IvSaleHdVM>();

                return Json(new { dtParms.draw, recordsFiltered = recordsTotal, recordsTotal, data }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<ActionResult> PostIvSaleHd(IvSaleHdVM vm)
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
                    trigger = Front.Helpers.Enums.Common.FormTriggers.Update.ToString(),
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

        public async Task<JsonResult> PrintsaleScreen(string id, string lang)
        {
            long longId = Convert.ToInt64(CipherStringController.Decrypt(id));

            var input = new IdLangInputDto { Id = longId, Lang = lang };

            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetSalesScreenData", RestSharp.Method.GET, input.ToString());

            if (response.success)
            {
                var dataConverted = Helper<List<rptSalesScreenData>>.Convert(JsonConvert.SerializeObject(response.result));

                var path = lang == "en-US" ? Server.MapPath("~/ReportsEn/rptSalesScreen_En.rpt") : Server.MapPath("~/Reports/rptSalesScreen.rpt");


                ReportDocument cryRpt = new ReportDocument();
                cryRpt.Load(path);
                cryRpt.SetDataSource(dataConverted);

                cryRpt.SetParameterValue("title", ERP.ResourcePack.Sales.IvSaleHd.rptSalesScreenTitle);

                Session["DocumentRpt"] = cryRpt;
                return Json(dataConverted, JsonRequestBehavior.AllowGet);

            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }

    }
}