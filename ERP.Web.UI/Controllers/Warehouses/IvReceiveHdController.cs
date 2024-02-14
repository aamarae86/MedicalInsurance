using CrystalDecisions.CrystalReports.Engine;
using ERP._System.__Warehouses._IvReceiveHd.Dto;
using ERP._System.PostRecords.Dto;
using ERP.Authorization;
using ERP.Front.Helpers.Core;
using ERP.Front.Helpers.DataTableHelpers;
using ERP.Front.Helpers.Parameters;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Models.ReportModels;
using ERP.Web.UI.Models.ResultModels;
using ERP.Web.UI.Models.ViewModels.Warehouses;
using ERP.WebUI.Controllers.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ERP.Web.UI.Controllers.Warehouses
{
    public class IvReceiveHdController : BaseController
    {
        public IvReceiveHdController() : base("IvReceiveHd", PermissionNames.Pages_IvReceiveHd_Insert) { }

        #region Views
        public async Task<ActionResult> FormView(string id, string t)
        {
            var (allPermissions, insertPermission) = await GetMainPermissions();

            TempData["Permissions"] = allPermissions;

            ViewBag.trigger = CipherStringController.Decrypt(t);

            ViewData["Id"] = string.IsNullOrEmpty(id) ? null : CipherStringController.Decrypt(id);

            if (!string.IsNullOrEmpty(id))
            {
                long decId = Convert.ToInt64(CipherStringController.Decrypt(id));

                if (!allPermissions.Contains(PermissionNames.Pages_IvReceiveHd_Update))
                    return RedirectToAction("Index", "Home", new { area = string.Empty });

                var response2 = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetDetailAsync?Id={decId}", RestSharp.Method.GET);
               
                var obj = Helper<IvReceiveHdVM>.Convert(JsonConvert.SerializeObject(response2.result));
                decimal? total = 0;
                foreach (var item in obj.IvReceiveTr)
                {
                    total += item.Amount+item.TaxAmount;
                }
                ViewData["total"] = total;
                ViewData["DetailAsync"] =obj;
            }
            else
            {
                if (!insertPermission.Contains(PermissionNames.Pages_IvReceiveHd_Insert))
                    return RedirectToAction("Index", "Home", new { area = string.Empty });
            }

            return View();
        }

        public PartialViewResult IvReceiveHdSearch() => PartialView();

        public PartialViewResult IvReceiveHdData() => PartialView();

        public PartialViewResult IvReceiveHdForm(long? id, string trigger, IvReceiveHdVM IvReceiveHdVM)
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

                return PartialView(IvReceiveHdVM);
            }

            return PartialView();
        }

        public PartialViewResult IvReceiveDataDetail() => PartialView();

        public PartialViewResult IvReceiveFormDetail(long? id, string trigger)
        {
            ViewBag.trigger = trigger;
            return PartialView();
        }

        #endregion

        #region Actions

        public async Task<ActionResult> LoadDataGrid(IvReceiveHdSearchDto searchParms)
        {
            var dtParms = DataTableParmsHelper.GetParms(Request.Form);

            var parameters = new GetAllPagedAndSortedWithParams<IvReceiveHdSearchDto>()
            {
                Params = searchParms,
                Sorting = dtParms.sort.PairAsSqlExpression,
                OrderByValue = dtParms.sort,
                MaxResultCount = dtParms.pageSize,
                SkipCount = dtParms.skip
            };

            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetAll", RestSharp.Method.GET, parameters);

            var dataConverted = Helper<ListResultBaseWithTotalRecords<IvReceiveHdVM>>.Convert(JsonConvert.SerializeObject(response.result));

            int recordsTotal = dataConverted?.totalCount ?? 0;
            var data = dataConverted?.Items ?? new List<IvReceiveHdVM>();

            foreach (var item in data)
                item.Amount = Math.Round(item.IvReceiveTr.Sum(x => x.Amount+ (x.TaxAmount!=null?(decimal)x.TaxAmount:0)), 3).ToString();

            return Json(new { dtParms.draw, recordsFiltered = recordsTotal, recordsTotal, data }, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> PostIvReceiveHd(IvReceiveHdVM vm)
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

        public async Task<JsonResult> PrintIvReceiveHdScreen(string id, string lang)
        {
            long longId = Convert.ToInt64(CipherStringController.Decrypt(id));

            var input = new IdLangInputDto { Id = longId, Lang = lang };

            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetIvReceiveHdScreenData", RestSharp.Method.GET, input.ToString());

            if (response.success)
            {
                var dataConverted = Helper<List<rptIvReceiveHdScreenData>>.Convert(JsonConvert.SerializeObject(response.result));

                var path = lang == "en-US" ? Server.MapPath("~/ReportsEn/rptIvReceiveHdScreen_En.rpt") : Server.MapPath("~/Reports/rptIvReceiveHdScreen.rpt");


                ReportDocument cryRpt = new ReportDocument();
                cryRpt.Load(path);
                cryRpt.SetDataSource(dataConverted);

                cryRpt.SetParameterValue("title",ERP.ResourcePack.Accounts.ReportsAccounts.rptIvReceiveHdScreenTitle);

                Session["DocumentRpt"] = cryRpt;
                return Json(dataConverted, JsonRequestBehavior.AllowGet);
            }



            return Json(false, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}