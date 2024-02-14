using ERP._System._ArCustomers.Dto;
using ERP.Authorization;
using ERP.Front.Helpers.Core;
using ERP.Front.Helpers.DataTableHelpers;
using ERP.Front.Helpers.Parameters;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Models.ResultModels;
using ERP.Web.UI.Models.ViewModels.Accounts;
using ERP.WebUI.Controllers.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using static ERP.Front.Helpers.Enums.Common;

namespace ERP.Web.UI.Controllers.Accounts
{
    public class ArCustomersController : BaseController
    {
        public ArCustomersController() : base("ArCustomers", PermissionNames.Pages_ArCustomers_Insert) { }

        public PartialViewResult ArCustomersSearch() => PartialView();

        public PartialViewResult ArCustomersData() => PartialView();

        public async Task<PartialViewResult> ArCustomersForm(int? id, string trigger)
        {
            if (id == null && trigger == ERP.Front.Helpers.Enums.Common.FormTriggers.Insert.ToString())
            {
                ViewBag.trigger = trigger;

                return PartialView();
            }
            else if (id != null && trigger == ERP.Front.Helpers.Enums.Common.FormTriggers.Update.ToString() ||
                trigger == ERP.Front.Helpers.Enums.Common.FormTriggers.Show.ToString())
            {
                var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetDetailAsync?Id={id}", RestSharp.Method.GET);

                var dataConverted = Helper<ArCustomersVM>.Convert(JsonConvert.SerializeObject(response.result));

                ViewBag.trigger = trigger;

                return PartialView(dataConverted);
            }

            return PartialView();
        }

        public async Task<ActionResult> LoadDataGrid(ArCustomersSearchDto searchParms)
        {
            var dtParms = DataTableParmsHelper.GetParms(Request.Form);


            var parameters = new GetAllPagedAndSortedWithParams<ArCustomersSearchDto>()
            {
                Params = searchParms,
                OrderByValue = dtParms.sort,
                SkipCount = dtParms.skip,
                MaxResultCount = dtParms.pageSize
            };


            var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetAll", RestSharp.Method.GET, parameters);

            var dataConverted = Helper<ListResultBaseWithTotalRecords<ArCustomersVM>>.Convert(JsonConvert.SerializeObject(response.result));

            int recordsTotal = dataConverted?.totalCount ?? 0;
            var data = dataConverted?.Items ?? new List<ArCustomersVM>();

            return Json(new { dtParms.draw, recordsFiltered = recordsTotal, recordsTotal, data }, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> PostArCustomers(ArCustomersVM vm)
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
        public async Task<ActionResult> CheckIsExistsCustomerNameAr(string CustomerNameAr, string Id)
        {
            try
            {
                //var x = IsExists(input).Result;
                var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetExistCustomerNameArAsync?input={CustomerNameAr}&Id={Id}", RestSharp.Method.GET);
                var dataConverted = (bool)response.result;
                return Json(!dataConverted);
            }
            catch (Exception e)
            {
                return Json(false);
            }
        }

        [HttpPost]
        public async Task<ActionResult> CheckIsExistsCustomerNameEn(string CustomerNameEn, string Id)
        {
            try
            {
                var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetExistCustomerNameEnAsync?input={CustomerNameEn}&Id={Id}", RestSharp.Method.GET);
                var dataConverted = (bool)response.result;
                return Json(!dataConverted);
            }
            catch (Exception e)
            {
                return Json(false);
            }
        }

        

        [HttpPost]
        public async Task<ActionResult> CheckCustomerTypeIsAlreadyExist(long CustomerTypeLkpId, string Id)
        {
            try
            {
                if(CustomerTypeLkpId != 11566)
                    return Json(true);

                var response = await _restClientContainer.SendRequest<RestResult>($"{_apiAppService}/GetExistCustomerTypeAsync?input={CustomerTypeLkpId}&Id={Id}", RestSharp.Method.GET);
                var dataConverted = (bool)response.result;
               
                return Json(!dataConverted);
            }
            catch (Exception e)
            {
                return Json(false);
            }
        }

    }
}