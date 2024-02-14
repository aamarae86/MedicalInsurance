using ERP._System.__SalesModule._FndSalesMen.Dto;
using ERP.Authorization;
using ERP.Front.Helpers.Core;
using ERP.Front.Helpers.DataTableHelpers;
using ERP.Front.Helpers.Parameters;
using ERP.Front.Helpers.Repository;
using ERP.Helpers.Core;
using ERP.ResourcePack.Common;
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
        public class FndSalesMenController : BaseController
        {
            public FndSalesMenController() : base("FndSalesMen", PermissionNames.Pages_FndSalesMen_Insert) { }

            public PartialViewResult FndSalesMenSearch() => PartialView();

            public PartialViewResult FndSalesMenData() => PartialView();

            public async Task<PartialViewResult> FndSalesMenForm(int? id, string trigger)
            {
                if (id == null && trigger == Front.Helpers.Enums.Common.FormTriggers.Insert.ToString())
                {
                    ViewBag.trigger = trigger;

                    return PartialView();
                }
                else if (id != null && trigger == Front.Helpers.Enums.Common.FormTriggers.Update.ToString() ||
                    trigger == Front.Helpers.Enums.Common.FormTriggers.Show.ToString())
                {
                    var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/Get?Id={id}", RestSharp.Method.GET);

                    var dataConverted = Helper<FndSalesMenVM>.Convert(JsonConvert.SerializeObject(response.result));

                    ViewBag.trigger = trigger;

                    return PartialView(dataConverted);
                }

                return PartialView();
            }

            public async Task<ActionResult> LoadDataGrid(FndSalesMenSearchDto searchParms)
            {
                var dtParms = DataTableParmsHelper.GetParms(Request.Form);

                var parameters = new GetAllPagedAndSortedWithParams<FndSalesMenSearchDto>()
                {
                    Params = searchParms,
                    OrderByValue = dtParms.sort,
                    SkipCount = dtParms.skip,
                    MaxResultCount = dtParms.pageSize
                };

                var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetAll", RestSharp.Method.GET, parameters);

                var dataConverted = Helper<ListResultBaseWithTotalRecords<FndSalesMenVM>>.Convert(JsonConvert.SerializeObject(response.result));

                int recordsTotal = dataConverted?.totalCount ?? 0;
                var data = dataConverted?.Items ?? new List<FndSalesMenVM>();

                return Json(new { dtParms.draw, recordsFiltered = recordsTotal, recordsTotal, data }, JsonRequestBehavior.AllowGet);
            }

            public async Task<ActionResult> PostFndSalesMen(FndSalesMenVM vm)
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

            [HttpPost]
            public async Task<ActionResult> CheckIsExistsSalesMenNameAr(string SalesMenNameAr, string Id)
            {
                try
                {
                    var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetExistSalesMenNameArAsync?input={SalesMenNameAr}&Id={Id}", RestSharp.Method.GET);
                    var dataConverted = (bool)(response.result != null ? response.result : false);

                    return Json(!dataConverted);
                }
                catch (Exception x)
                {
                    return Json(false);
                }
            }

            [HttpPost]
            public async Task<ActionResult> CheckIsExistsSalesMenNameEn(string SalesMenNameEn, string Id)
            {
                try
                {
                    var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetExistSalesMenNameEnAsync?input={SalesMenNameEn}&Id={Id}", RestSharp.Method.GET);
                    var dataConverted = (bool)(response.result != null ? response.result : false);

                    return Json(!dataConverted);
                }
                catch (Exception x)
                {
                    return Json(false);
                }
            }

        }
    
}