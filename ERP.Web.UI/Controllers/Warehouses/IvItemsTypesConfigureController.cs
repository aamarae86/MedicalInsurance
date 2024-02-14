using ERP._System.__Warehouses._IvItemsTypesConfigure.Dto;
using ERP.Authorization;
using ERP.Front.Helpers.Core;
using ERP.Front.Helpers.DataTableHelpers;
using ERP.Front.Helpers.Parameters;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Models.ResultModels;
using ERP.Web.UI.Models.ViewModels.Warehouses;
using ERP.WebUI.Controllers.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using static ERP.Front.Helpers.Enums.Common;

namespace ERP.Web.UI.Controllers.Warehouses
{
    public class IvItemsTypesConfigureController : BaseController
    {
        public IvItemsTypesConfigureController() : base("IvItemsTypesConfigure", PermissionNames.Pages_IvItemsTypesConfigure_Insert) { }

        public PartialViewResult IvItemsTypesConfigureSearch() => PartialView();

        public PartialViewResult IvItemsTypesConfigureData() => PartialView();

        public async Task<PartialViewResult> IvItemsTypesConfigureForm(long? id, string trigger)
        {
            if (id == null && trigger == FormTriggers.Insert.ToString())
            {
                ViewBag.trigger = trigger;

                return PartialView();
            }
            else if (id != null && trigger == FormTriggers.Update.ToString() || trigger == FormTriggers.Show.ToString())
            {
                var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetDetailAsync?Id={id}", RestSharp.Method.GET);

                var dataConverted = Helper<IvItemsTypesConfigureVM>.Convert(JsonConvert.SerializeObject(response.result));

                ViewBag.trigger = trigger;

                return PartialView(dataConverted);
            }

            return PartialView();
        }

        public async Task<ActionResult> LoadDataGrid(IvItemsTypesConfigureSearchDto searchParms)
        {
            var dtParms = DataTableParmsHelper.GetParms(Request.Form);

            var parameters = new GetAllPagedAndSortedWithParams<IvItemsTypesConfigureSearchDto>()
            {
                Params = searchParms,
                OrderByValue = dtParms.sort,
                SkipCount = dtParms.skip,
                MaxResultCount = dtParms.pageSize
            };

            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetAll", RestSharp.Method.GET, parameters);

            var dataConverted = Helper<ListResultBaseWithTotalRecords<IvItemsTypesConfigureVM>>.Convert(JsonConvert.SerializeObject(response.result));

            int recordsTotal = dataConverted?.totalCount ?? 0;
            var data = dataConverted?.Items ?? new List<IvItemsTypesConfigureVM>();

            return Json(new { dtParms.draw, recordsFiltered = recordsTotal, recordsTotal, data }, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> PostIvItemsTypesConfigure(IvItemsTypesConfigureVM vm)
        {
            if (vm.Id == 0)
            {
                var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/Create", RestSharp.Method.POST, vm);

                response.customRestResult = new CustomRestResult()
                {
                    trigger = FormTriggers.Insert.ToString(),
                    message = response.success ? Settings.AddedSuccessfully : $"{Settings.Error} : {response.error.message}"
                };

                return Json(response, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/Update", RestSharp.Method.PUT, vm);

                response.customRestResult = new CustomRestResult()
                {
                    trigger = FormTriggers.Update.ToString(),
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
        public async Task<ActionResult> CheckIsExistsCode(string ConfigureCode, long Id = 0)
        {
            try
            {
                var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetExistConfigureCodeAsync?input={ConfigureCode}&Id={Id}", RestSharp.Method.GET);
                return Json(!(bool)response.result);
            }
            catch (Exception e)
            {
                return Json(false);
            }
        }

        [HttpPost]
        public async Task<ActionResult> CheckIsExistsNameAr(string NameAr, long Id = 0)
        {
            try
            {
                var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetExistNameArAsync?input={NameAr}&Id={Id}", RestSharp.Method.GET);

                return Json(!(bool)response.result);
            }
            catch (Exception e)
            {
                return Json(false);
            }
        }

        [HttpPost]
        public async Task<ActionResult> CheckIsExistsNameEn(string NameEn, long Id = 0)
        {
            try
            {
                var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetExistNameEnAsync?input={NameEn}&Id={Id}", RestSharp.Method.GET);

                return Json(!(bool)response.result);
            }
            catch (Exception e)
            {
                return Json(false);
            }
        }
    }
}