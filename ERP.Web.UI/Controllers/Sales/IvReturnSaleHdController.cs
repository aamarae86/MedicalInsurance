using CrystalDecisions.CrystalReports.Engine;
using ERP._System.__SalesModule._FndSalesMen.Dto;
using ERP._System.__SalesModule._IvReturnSaleHd.Dto;
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
    public class IvReturnSaleHdController : BaseController
    {
        // GET: IvReturnSaleHd
        public IvReturnSaleHdController() : base("IvReturnSaleHd", PermissionNames.Pages_IvReturnSaleHd_Insert) { }

        public PartialViewResult IvReturnSaleHdSearch() => PartialView();

        public PartialViewResult IvReturnSaleHdData() => PartialView();
        public PartialViewResult IvReturnSaleHdDataDetail() => PartialView();

        public PartialViewResult IvReturnSaleHdFormDetail(long? id, string trigger)
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

                //if (!allPermissions.Contains(PermissionNames.Pages_IvReturnSaleHd_Update))
                //    return RedirectToAction("Index", "Home", new { area = string.Empty });

                var response2 = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetDetailAsync?Id={decId}", RestSharp.Method.GET);

                ViewData["DetailAsync"] = Helper<IvReturnSaleHdVM>.Convert(JsonConvert.SerializeObject(response2.result));
            }
            else
            {
                ViewData["ReturnDate"]=DateTime.Now.ToString("dd/MM/yyyy");
                if (!insertPermission.Contains(PermissionNames.Pages_IvReturnSaleHd_Insert))
                    return RedirectToAction("Index", "Home", new { area = string.Empty });
            }

            return View();


        }

        public PartialViewResult IvReturnSaleHdForm(long? id, string trigger, IvReturnSaleHdVM IvReturnSaleHdVM)
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

                return PartialView(IvReturnSaleHdVM);
            }

            return PartialView();
        }



        public async Task<ActionResult> LoadDataGrid(IvReturnSaleHdSearchDto searchParms)
        {
            try
            {
                var dtParms = DataTableParmsHelper.GetParms(Request.Form);

                var parameters = new GetAllPagedAndSortedWithParams<IvReturnSaleHdSearchDto>()
                {
                    Params = searchParms,
                    Sorting = dtParms.sort.PairAsSqlExpression,
                    OrderByValue = dtParms.sort,
                    MaxResultCount = dtParms.pageSize,
                    SkipCount = dtParms.skip
                };

                var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetAll", RestSharp.Method.GET, parameters);

                var dataConverted = Helper<ListResultBaseWithTotalRecords<IvReturnSaleHdVM>>.Convert(JsonConvert.SerializeObject(response.result));

                int recordsTotal = dataConverted?.totalCount ?? 0;
                var data = dataConverted?.Items ?? new List<IvReturnSaleHdVM>();

                return Json(new { dtParms.draw, recordsFiltered = recordsTotal, recordsTotal, data }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public async Task<ActionResult> PostIvReturnSaleHd(IvReturnSaleHdVM vm)
        {
            if (vm.Id == 0)
            {
                var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/Create", RestSharp.Method.POST, vm);


                if (response != null)
                {


                    var response2 = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/PostReturnSale", RestSharp.Method.POST, response.result);

                }

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






    }
}